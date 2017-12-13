const int xPin = 1;
const int yPin = 5;
const int zPin = 2;

const int analogOutPin = 1;

int x, y, z;

void setup() 
{
  pinMode(xPin, INPUT);
  pinMode(yPin, INPUT);
  pinMode(zPin, INPUT);

  pinMode(analogOutPin, OUTPUT);
}

void loop() 
{
  
  // Read in analog reading
  x = analogRead(xPin);
  x-=330;
  y = analogRead(yPin);
  y-=330;
  z = analogRead(zPin);
  z-=250;

  float length = sqrt(x*x + y*y + z*z);

  int tiltAngle = acos(z/length) * 57.29f;
  //analogWrite(analogOutPin, tiltAngle);//(x+330)/3);
  analogWrite(analogOutPin, (z+250)/2);

//if(y>0)
//  analogWrite(analogOutPin, 255);
//else
//  analogWrite(analogOutPin, 0);
  /*static int a=0;
  a++;
  analogWrite(analogOutPin,a);
  delay(10);
  if(a>=255) a=0;
  //analogWrite(analogOutPin, 0);
  //delay(100);
  //analogWrite(analogOutPin, 255);
  //delay(100);    
  */                                                                                                                     
}
