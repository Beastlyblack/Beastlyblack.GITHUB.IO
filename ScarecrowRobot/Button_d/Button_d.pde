import ddf.minim.*; //https://www.andrew.cmu.edu/course/15-100mns/bn22.pdf - sound
import ddf.minim.analysis.*;
import ddf.minim.effects.*;
import ddf.minim.signals.*;
import ddf.minim.spi.*;
import ddf.minim.ugens.*;
import processing.serial.*;//https://learn.sparkfun.com/tutorials/connecting-arduino-to-processing

Animation animation1, animation2,animation3,animation4,animation5,animation6,animation7; ///processing animation sketeh 

Minim w;
AudioPlayer w1;



Serial myPort; // the serial port object 
String val ; // since we're doing serial handshaking, 
// we need to check if we've heard from the microcontroller
boolean firstContact = false; 
boolean check = false;
boolean motion = false;
boolean powerstate = false;
boolean lightchange = false;
float xpos;
float ypos;
int Mtime;
int Pdelay = 50;


void setup()
{
  //Mtime = millis();//store the current time
  size(800,800); // making the caves 500x500 pixels big
   background(255, 204, 0);
  frameRate(25);
  animation1 = new Animation("Idle_Image",1);
  animation2 = new Animation("Right_arm",29);
  animation3 = new Animation("Left_arm",28);
  animation4 = new Animation("red_eyes",1);
  animation5 = new Animation("red_eyes_and_light",1);
  animation6 = new Animation("light",1);
  animation7 = new Animation("Right_arm",1);
  
  w = new Minim(this);
  w1 = w.loadFile("wookie.wav",1024);
  myPort= new Serial(this,Serial.list()[1],9600);
  myPort.bufferUntil('\n');
  
 
}


void draw()
{
background(153, 153, 0);
  animation7.display(xpos,ypos);
  

 

 if((check == false) && (motion == true))
 {
  background(153, 153, 0);
  animation3.display(xpos,ypos);
 }
 else if(( check == true)&&(motion == false))
 {
  // background(155, 153, 0);
   animation4.display(xpos,ypos);
  //To_near_event();
 }
 if (lightchange == true)
{
  //background(153, 153, 0);
   animation6.display(xpos,ypos);
   myPort.write("1");
  
} 
else
if ((lightchange == true)&&(check == true))
{
  animation5.display(xpos,ypos);
  myPort.write("1");
  
}
else
{
  myPort.write("2");
}
  if (powerstate == false)
  {
    background(0, 0, 0);
     check = false;
      motion = false;
    {
      noLoop();// processing
    }
  
  }
 //stop();
}


void serialEvent(Serial myPort)//put the incoming data into a string
{
  val = myPort.readStringUntil('\n');//the \n is the end delimiter say thats the end of the packet 
  
  if (val != null)//making sure the data is not empty before continuing 
  {
    val = trim(val); // trim whitespace and formatting characters(likr carriage return)
    println(val);
    
    if(firstContact ==false)
    {
      if (val.equals("A"))
      { 
        myPort.clear();
        firstContact =true;
        myPort.write("A");
        println("contact");
        check = false;
      }
    }
    else
    {  
      if (val.equals("B")||(val.equals("B.1")))
      {
       hi_or_bye();
      }
      else
      if (val.equals("C"))
      {
        To_near_event();
      }
      else
      if(val.equals("D"))
      {
        shutdown();
      }
      else
      if(val.equals("E"))
      {
        lightevent();
      }
      else
      {
      check = false;
      motion = false;
      lightchange = false;
      }
      // if we already have established contact 
     // buttoncheck();
    }
  }
  
}
  
void lightevent()
{
  lightchange = true;
} 
 
    
void hi_or_bye()
{
 int i = 0  ;
      if (val.equals("B"))
      {
       // if (i <= 58)
        {
          i++;
          check = false; 
          motion = true;
        }
      }
      else //if (val.equals("B.1"))
      //{
       
        motion = false;
        //check = false;
        i=0;
      //}
}
void shutdown()
{
   if (powerstate == true)
  {
    loop();
  } 
  powerstate = !powerstate;
}
  
void stop()
{
  w1.close();
  w.stop();
  super.stop();
}
void To_near_event()
{
  { 
   check = true ; 
   motion = false;
    w1.play();
   //w1.rewind( );
  
  } /*else if (millis() - Ptime >= Pdelay)
    {
      check = false ;
    } */
  
}
/*void mousePressed()
{
  if (mousePressed == true && buttonpress == true )
  {
      myPort.write('1');
      println("stage 1");
      
  }
}*/
        
        
    
  