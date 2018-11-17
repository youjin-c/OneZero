#include <Wire.h>

char message[25] = {};
int aa,bb;
String AA;
String bufferString;
void setup()
{
   Wire.begin();
   Serial.begin(9600);
}

void loop()
{
   while (0 < Serial.available()) {            // loop through all the received bytes 
      bufferString = Serial.readStringUntil('\n'); 
   }     
  requestValues(2);
  AA = String(message);
  aa = AA.indexOf("[");
  bb = AA.indexOf("]");
  AA = AA.substring(aa+1,bb);
  Serial.println(AA);
  delay(29);
}

void requestValues(int slave)
{ 
  int i = 0;
  // Request value from slave
  Wire.requestFrom(slave, 15); //size of this string can vary from 10 up to 15
  while(Wire.available() > 0)
  {
    message[i] = Wire.read();
    i++;
  }
  message[i] = '\0';
}
