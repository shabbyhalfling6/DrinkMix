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
}

void loop() 
{
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
  

    //tiltAngle = analogRead(Bottle1_TiltPin);
    int v = pulseIn(A0,HIGH,4200);
    v = map(v,600,900,0,255);
    Serial.write(v);
    
    delay(30);
}
