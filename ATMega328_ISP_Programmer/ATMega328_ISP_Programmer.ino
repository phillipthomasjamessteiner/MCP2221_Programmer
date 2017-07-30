#include <SPI.h>
#include <Wire.h>

#define SCK 13
#define DONEPIN 7
#define RSTPIN 8

/* 
 *  0: Command Mode - Idle
 *  1: Connect to Device
 *  2: Program Device
 *  3: Read Program from Device
 */
 
uint8_t I2CState = 0;
/*
 * 0: Waiting for command byte one
 * 1: Waiting for command byte two
 * 2: Waiting for data byte
 */

byte I2CBuffer[3]; // Buffer for Bytes Recieved by I2C

byte pageSize = 32;

// Buffers
byte LowBytes[32];
byte HighBytes[32];
// ----------

byte SPIToSend[4];
byte SPIRecieved[4];

boolean deviceDone = true;
boolean inSync = false;

void setup() {
  pinMode(DONEPIN, OUTPUT);
  pinMode(RSTPIN, OUTPUT);
  pinMode(SCK, OUTPUT);

  SPI.begin();
  SPI.beginTransaction(SPISettings(14000000, MSBFIRST, SPI_MODE0));
  
  Wire.begin(8);
  Wire.onReceive(I2CRecieved);
  Wire.onRequest(I2CRequested);

  Serial.begin(9600);
}

void loop() {
  if (!deviceDone && inSync) {
    pollDevice();
  }
}

void I2CRecieved(int numBytes) {
  while (1 < Wire.available()) {
    
    switch (I2CState) {
      case 0:
        I2CBuffer[0] = Wire.read(); // Get Command Byte 1
        I2CState = 1;
        break;
      case 1:
        I2CBuffer[1] = Wire.read(); // Get Command Byte 2
        I2CState = 2;
        break;
      case 2:
        I2CBuffer[2] = Wire.read(); // Get Command Byte 2
        switch (I2CBuffer[0]) {
          case 1: // Set Low Page Byte at address in page
            loadFlashLowByte(I2CBuffer[1], I2CBuffer[2]);
            DeviceWorking();
            break;
          case 2: // Set High Page Byte at address in page
            loadFlashHighByte(I2CBuffer[1], I2CBuffer[2]);
            DeviceWorking();
            break;
          case 3: // Write page to AVR device
            writePageToDevice(I2CBuffer[2]);
            DeviceWorking();
            break;
          case 4: // Write page size to programmer
            pageSize = I2CBuffer[2];
            break;
          case 5: // Read Page to Buffer
            readPageToBuffer(I2CBuffer[2]);
            break;
          case 8: // Enable AVR device in programming mode
            progEnable();
            break;
          case 9: // Erase AVR device memory (chip erase)
            chipErase();
            break;
          case 10: // Begin Startup Sequence
            startSequence();
            break;
        }
        I2CState = 0;
        break;
    }
  }
}

void I2CRequested() {
  if (I2CState == 2) {
    switch (I2CBuffer[0]) {
      case 6: // Read Low Byte from buffer at address
        Wire.write(LowBytes[I2CBuffer[1]]);
        break;
      case 7: // Read High Byte from buffer at address
        Wire.write(HighBytes[I2CBuffer[1]]);
        break;
      case 11: // Echo Byte (Test Connection with MCP2221)
        Wire.write(I2CBuffer[1]);
        break;
    }
    I2CState = 0;
  }
}

void startSequence() {
  DeviceWorking();
  inSync = false;
  digitalWrite(SCK, LOW);
  digitalWrite(RSTPIN, LOW);
  delay(2);

  digitalWrite(RSTPIN, HIGH);
  delay(2);
  digitalWrite(RSTPIN, LOW);
}

void progEnable() {
  DeviceWorking();
  
  while (!inSync) {
    SPIToSend[0] = 172;
    SPIToSend[1] = 83;
    SPIToSend[2] = 0;
    SPIToSend[3] = 0;
    transferSPI();
    if (SPIRecieved[2] == 83) { // if byte 3 echos back as 0x53 (83) we are in sync
      inSync = true;
      
      deviceDone = true;
      digitalWrite(DONEPIN, HIGH);
    }
    else {
      startSequence();
    }
  }
}

void chipErase() {
  SPIToSend[0] = 172;
  SPIToSend[1] = 128;
  SPIToSend[2] = 0;
  SPIToSend[3] = 0;
  transferSPI();
}

void loadFlashLowByte(byte address, byte data) {
  SPIToSend[0] = 64;
  SPIToSend[1] = 0;
  SPIToSend[2] = (address & B00011111);
  SPIToSend[3] = data;
  transferSPI();
}

void loadFlashHighByte(byte address, byte data) {
  SPIToSend[0] = 72;
  SPIToSend[1] = 0;
  SPIToSend[2] = (address & B00011111);
  SPIToSend[3] = data;
  transferSPI();
}

void writePageToDevice(byte address) {
  SPIToSend[0] = 76;
  SPIToSend[1] = (address >> 3);
  SPIToSend[2] = (address << 5);
  SPIToSend[3] = 0;
  transferSPI();
}

void readPageToBuffer(byte address) {
  for (uint8_t w = 0; w < pageSize; w++) {
    SPIToSend[0] = 32; // Read the low byte first...
    SPIToSend[1] = (address >> 3);
    SPIToSend[2] = ((address << 5) | w);
    SPIToSend[3] = 0;
    transferSPI();
    LowBytes[w] = SPIRecieved[3];

    
    SPIToSend[0] = 40; // ... then do the high byte
    SPIToSend[1] = (address >> 3);
    SPIToSend[2] = ((address << 5) | w);
    SPIToSend[3] = 0;
    transferSPI();
    HighBytes[w] = SPIRecieved[3];
  }
}

void pollDevice() {
  SPIToSend[0] = 240;
  SPIToSend[1] = 0;
  SPIToSend[2] = 0;
  SPIToSend[3] = 0;
  transferSPI();
  if ((SPIRecieved[3] & 1) == 0) {
    deviceDone = true;
    digitalWrite(DONEPIN, HIGH);
  }
}

void DeviceWorking() {
  deviceDone = false;
  digitalWrite(DONEPIN, LOW);
}

void transferSPI() {
  SPIRecieved[0] = SPI.transfer(SPIToSend[0]); // Byte 1
  SPIRecieved[1] = SPI.transfer(SPIToSend[1]);
  SPIRecieved[2] = SPI.transfer(SPIToSend[2]);
  SPIRecieved[3] = SPI.transfer(SPIToSend[3]); // Byte 4
}



