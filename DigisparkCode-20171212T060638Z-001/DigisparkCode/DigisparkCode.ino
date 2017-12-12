const int xPin = 1;
const int yPin = 3;
const int zPin = 2;

const int analogOutPin = 0;

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
  z-=330;

  float length = sqrt(x*x + y*y + z*z);

  int tiltAngle = acos(z/length) * 57.29f;
  analogWrite(analogOutPin, tiltAngle);                                                                                                                         
}
