#include <NewPing.h>
#include <Wire.h>

#define SONAR_NUM 2      // Number of sensors.
#define MAX_DISTANCE 200 // Maximum distance (in cm) to ping.
#define LIGHT_BULB 13
#define TRIGGER0 6
#define ECHO0 7
#define TRIGGER1 12
#define ECHO1 11

NewPing sonar[SONAR_NUM] = {   // Sensor object array.
  NewPing(TRIGGER0, ECHO0, MAX_DISTANCE), // Each sensor's trigger pin, echo pin, and max distance to ping. 
  NewPing(TRIGGER1, ECHO1, MAX_DISTANCE)
};
String bufferString;
int wall0, wall1;
int temp0, temp1;
char message[25];
int reset;

void setup() {
  Serial.begin(9600); // Open serial monitor at 9600 baud to see ping results.
  pinMode(LIGHT_BULB,OUTPUT);
  pinMode(TRIGGER0,OUTPUT);
  pinMode(ECHO0,INPUT);
  pinMode(TRIGGER1,OUTPUT);
  pinMode(ECHO1,INPUT);

  Wire.begin(2); //I2C communication
  Wire.onRequest(requestEvent);
}

void loop() {
  while (Serial.available() >0) {            // loop through all the received bytes 
    bufferString = Serial.readStringUntil('\n'); 
  }     
  wall0 = sonar[0].ping_cm();
  wall1 = sonar[1].ping_cm();
  /*//optimization: smoothing part loaction loop|requestEvent. check the sync.
  if(wall0!=0){temp0 = wall0;}else{wall0=temp0;}
  if(wall1!=0){temp1 = wall1;}else{wall1=temp1;}*/
  Serial.print(wall0);
  Serial.print(",");
  Serial.println(wall1);
  if(bufferString == "HIGH"){
    digitalWrite(13,HIGH);
  }else if(bufferString =="LOW"){
    digitalWrite(13,LOW);
  }
  delay(29);//29ms is the minimum delay for NewPing library
}
void requestEvent()
{
  //taking unstable 0 values from ultrasonic sensor.  
  //optimization: smoothing part loaction loop|requestEvent. check the sync.
  if(wall0!=0){temp0 = wall0;}else{wall0=temp0;}
  if(wall1!=0){temp1 = wall1;}else{wall1=temp1;}
  
  if(bufferString !="HIGH" && bufferString !="LOW"){
    reset = bufferString.toInt(); //1 indicates new ball initiated in the unity scene.
    }
  sprintf(message, "[%d,%d,%d]", wall0, wall1,reset);
  Wire.write(message);
}
