int tiltAngle = 0;
int state=0;
int target = 0;

void setup()
{
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("Uno");
  pinMode(8,INPUT);
}

void loop()
{
  int t;
  static float v[4]={0};
  for(int i=0; i<4; i++)
  {
    v[i] = pulseIn(8+i,HIGH,40200)*0.2f+v[i]*0.8f;
    int b = map(v[i],1000,1300,0,63);
    if(b>63) b=63;
    if(b<0) b=0;
    b = b | (i<<6);
    Serial.write((char)b);
    delay(30);
  }
}

