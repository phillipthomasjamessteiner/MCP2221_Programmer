#include <Wire.h>

#define NUM_PAGES 64
#define PAGES_IN_WORD 32

uint8_t I2CState = 0;

void setup() {
  Serial.begin(9600);
  Serial.println("Serial begin");
  Wire.begin(11);
  Wire.onRequest(I2CRequested);
  Wire.onReceive(I2CRecieved);
}

void loop() {
    
}

void I2CRequested() {
  switch(I2CState) {
    case 0: // Wait for Connect - Return 5 on request
      Wire.write(5);
      Serial.println("sent");
      I2CState = 1;
      break;
  }
}

void I2CRecieved(uint8_t numBytes) {
  byte dataRecieved = Wire.read();
  switch(dataRecieved) {
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
      I2CState = 0; // Return 5 on request
      break;
    
  }
  Serial.println(dataRecieved);
}

