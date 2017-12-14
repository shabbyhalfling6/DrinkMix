#include <Adafruit_NeoPixel.h>

#define Bottle1_LEDPIN 3
#define Bottle2_LEDPIN 4
#define Bottle3_LEDPIN 5
#define Bottle4_LEDPIN 6

#define Bottle1_TiltPin A0

#define NUM_LEDS 1

#define BRIGHTNESS 100

int tiltAngle = 0;
int red, green, blue;

Adafruit_NeoPixel bottle1LED = Adafruit_NeoPixel(NUM_LEDS, Bottle1_LEDPIN, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel bottle2LED = Adafruit_NeoPixel(NUM_LEDS, Bottle2_LEDPIN, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel bottle3LED = Adafruit_NeoPixel(NUM_LEDS, Bottle3_LEDPIN, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel bottle4LED = Adafruit_NeoPixel(NUM_LEDS, Bottle4_LEDPIN, NEO_GRB + NEO_KHZ800);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("Uno");

  bottle1LED.setBrightness(BRIGHTNESS);
  bottle2LED.setBrightness(BRIGHTNESS);
  bottle3LED.setBrightness(BRIGHTNESS);
  bottle4LED.setBrightness(BRIGHTNESS);

  bottle1LED.begin();
  bottle2LED.begin();
  bottle3LED.begin();
  bottle4LED.begin();
  
  bottle1LED.show();
  bottle2LED.show();
  bottle3LED.show();
  bottle4LED.show();
  pinMode(8,INPUT);
 
}
int state=0;
int target = 0;

void loop() 
{
  int b;
  switch(state)
  {
    case 0: // wait for magic
    if(Serial.available() > 0)
    {
      b = Serial.read();
      if((b&252)==0x18)
      {
        state=1;
        target = b&3;
      }
    }
    break;
    case 1: // wait for red
    if(Serial.available() > 0)
    {
      red = Serial.read();
      state=2;
      if((red&252)==0x18)
      {
        state=1;
      }
    }
    break;
    case 2: // wait for green
    if(Serial.available() > 0)
    {
     green = Serial.read();
     state=3;
           if((green&252)==0x18)
      {
        state=1;
      }
    }
    break;
    case 3: // wait for blue
    if(Serial.available() > 0)
    {
      blue = Serial.read();
      state=0;
            if((blue&252)==0x18)
      {
        state=1;
      }
      else
      {
        uint32_t colorvalue;
        switch(target)
        {
          case 0:
                colorvalue = bottle1LED.Color( red, green, blue);
                bottle1LED.setPixelColor(0, colorvalue);
                bottle1LED.show();
          break;
          case 1:
                colorvalue = bottle2LED.Color( red, green, blue);
                bottle2LED.setPixelColor(0, colorvalue);
                bottle2LED.show();
          break;
          case 2:
                colorvalue = bottle3LED.Color( red, green, blue);
                bottle3LED.setPixelColor(0, colorvalue);
                bottle3LED.show();
          break;
          case 3:
                colorvalue = bottle4LED.Color( red, green, blue);
                bottle4LED.setPixelColor(0, colorvalue);
                bottle4LED.show();
          break;
        }
      colorvalue = bottle1LED.Color( red, green, blue);
      bottle1LED.setPixelColor(0, colorvalue);
      bottle1LED.show();
      }
    }
    break;
  }
  /*
    if(Serial.available() > 0)
    {
      red = Serial.read();
    }
    if(Serial.available() > 0) 
    {
      green = Serial.read();
    }
    if(Serial.available() > 0) 
    {
      blue = Serial.read();
    }

    uint32_t colorvalue = bottle1LED.Color( red, green, blue);
    bottle1LED.setPixelColor(0, colorvalue);
    bottle1LED.show();
  */

    int t;
    //t = analogRead(Bottle1_TiltPin);
    //Serial.println(t);
    static float v[4]={0};
    for(int i=0;i<4;i++)
    {
      v[i] = pulseIn(8+i,HIGH,40200)*0.2f+v[i]*0.8f;
      int b = map(v[i],1000,1300,0,63);
      if(b>63) b=63;
      if(b<0) b=0;
      b = b | (i<<6);
    Serial.write((char)b);
    delay(30);
    } 
   // v = map(v,600,900,0,255);
//    Serial.write(v);
    
}

