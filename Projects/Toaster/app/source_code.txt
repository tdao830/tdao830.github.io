Audio chime = new Audio();

int currentTime;
int[][] buttons = { {10, 10, 100, 50, 8}, {10, 10, 100, 50, 8}, {10, 700, 150, 75, 8}, {1170, 10, 100, 100, 8}, {1100, 122, 175, 42, 8}, {1100, 215, 175, 42, 8}, {1170, 450, 60, 60, 8}, {1170, 550, 60, 60, 8}, {1050, 10, 100, 100, 8}}; 
int[] buttonX = {100, 100, 150, 100, 175, 175, 60, 60, 100};
int[] buttonY = {50, 50, 75, 100, 42, 42, 60, 60, 100};
int[][] options = {{10, 550, 100, 50, 8}, {140, 570, 100, 50, 8}, {260, 630, 100, 50, 8}, {270, 720, 100, 50, 8}};
int[] optionX = {100, 100, 100, 100};
int[] optionY = {50, 50, 50, 50};
int[][] toastOpt = {{260,440,100,50,8}, {260,500,100,50,8}, {260,560,100,50,8}};
int[] toastX = {100, 100, 100};
int[] toastY = {50, 50, 50};
int optSelected = -1;
int toastSelected = -1;
int selected = -1;
int currTemp = 0;
int currTempC = 0;
int currTimerMin = 0;
int currTimerHr = 0; 
int prevSelected;
boolean bake = false;
boolean broil = false;
boolean toast = false;
boolean pizza = false;


void loadSounds()
{
  // sound from http://soundbible.com/1598-Electronic-Chime.html 
  chime.setAttribute("src", "chime.mp3");
  println("you loaded sound nigga");
}

void playChime()
{
  chime.play();
}

void setup()
{
  size(1280, 800);
  background(90,90,90);
  //smooth();
  loadSounds();
}

void draw()
{
  background(90,90,90);
  fill(0,0,0);
  
  /************ Simple Component ***************/
  
  // Drawing all the buttons
  fill(255,255,255);
  for(int i = 1; i < buttons.length; i++)
  {
    rect(buttons[i][0], buttons[i][1], buttonX[i], buttonY[i], 8);
  }
 
  // Drawing all text for buttons
  fill(0,0,0);
  textSize(25);
  text("Eject", 18, 45);
  //text("Default", 20, 105);
  textSize(40);
  text("Options", 18, 750);
  textSize(40);
  text("Start", 1058, 75);
  text("Stop", 1177, 75);


  //Temp and timer display
  textSize(35);
  text("Temp Set", 1110, 155);
  text(currTemp, 1180, 210);
  text("Timer Set", 1110, 250);
  text(currTimerHr + ":" + currTimerMin, 1165, 300); 
  text("+", 1188, 500);
  text("-", 1193, 590);
  
  // Display current temp in Toaster
  text("0 °F", 619, 725);
  text("-17 °C",590, 770);
  //Select button
  fill(0,0,100,50);
  if(selected >= 0)
  {
    rect(buttons[selected][0], buttons[selected][1], buttonX[selected], buttonY[selected], 8);
  }
  
  /************ Cooking Options *************/
  fill(0,0,0);
  switch(optSelected)
  {
    case 0:
      text("Bake", 610, 679);
      break;
    case 1:
      text("Broil", 610, 679);
      break;
    case 2:
      text("Toast", 610, 679);
      break;
    case 3:
      text("Pizza", 610, 679);
      break;
  }
  
  // Toast shade
  fill(0,0,0);
  if(optSelected == 2)
  {
    switch(toastSelected)
    {
      case 0:
        text("Light", 719, 679);
        break;
      case 1:
        text("Medium", 719, 679);
        break;
      case 2:
        text("Dark", 719, 679);
        break;
    }
  }
  
  /***** Options button *******/
  if(selected == 1)
  {
    textSize(60);
    text("EJECTING", 520, 380); 
  }
  if(selected == 2)
  {
    fill(255,255,255);
    for(int i = 0; i < options.length; i++)
    {
      rect(options[i][0], options[i][1], optionX[i], optionY[i], 8);
    }
    fill(0,0,0);
    text("Bake", 21, 582);
    text("Broil", 152, 601);
    text("Pizza", 275, 755);
    text("Toast", 269, 662);
    
    // Color selected button
    fill(0,0,100,50);
    if(optSelected >= 0)
    {
      rect(options[optSelected][0], options[optSelected][1], optionX[optSelected], optionY[optSelected], 8);
    }
    
    /****** Toast selected *********/
    if(optSelected == 2)
    {
      fill(255,255,255);
      for(int i = 0; i < toastOpt.length; i++)
      {
        rect(toastOpt[i][0], toastOpt[i][1], toastX[i], toastY[i], 8);
      }
      
      // Color selected button of toast
      fill(0,0,100,50);
      if(toastSelected >= 0)
      {
        rect(toastOpt[toastSelected][0], toastOpt[toastSelected][1], toastX[toastSelected], toastY[toastSelected], 8);
      }
      fill(0,0,0);
      textSize(25);
      text("Light", 280, 473);
      text("Medium", 266, 530);
      text("Dark", 282, 595);
    }
    prevSelected = 2;
  }
  
  /******** Stop Button ***********/
  if(selected == 3)
  {
    currTimerMin = 0;
    currTimerHr = 0;
    currTemp = 0;
    prevSelected = 3;
  }
  
  /******** Temp Set ***********/
  if(selected == 4)
  {
    textSize(100);
    text(currTemp + "°F", 580, 380);
    prevSelected = 4;
  }
  
  /********  Timer set ********/
  if(selected == 5)
  {
    textSize(100);
    text(currTimerHr + ":" + currTimerMin, 580, 380);
    prevSelected = 5;
  }
  
  /********* Plus ***********/
  if(selected == 6)
  {
    // Change temp
    if(prevSelected == 4)
    {
      currTemp += 5;
      selected = 4;
    }
    
    // Change timer
    if(prevSelected == 5)
    {
      if(currTimerMin <= 450)
      {
        currTimerMin += 5;
      }
      if(currTimerMin >= 60)
      {
        currTimerHr += 1;
        currTimerMin = 0;
      }
      selected = 5;
    }
  }
  
  /*********** Minus ************/
  if (selected == 7)
  {
    // Change Temp
    if(prevSelected == 4)
    {
      if(currTemp > 0)
      {
        currTemp -= 5;
      }
      selected = 4;
    }
    // Change Timer
    if(prevSelected == 5)
    {
      if(currTimerMin > 0)
      {
        currTimerMin -= 5;
      }
      else if(currTimerMin <= 0 && currTimerHr >= 1)
      {
        currTimerHr -= 1;
        currTimerMin = 55;
      }
      selected = 5;
    }
  }
  
  /********* Start button ************/
  if(selected == 8)
  {
    if(prevSelected != 8)
    {
      playChime();
    }
    textSize(100);
    currTimerMin -= (int)(1/6000);
    text(currTimerHr + ":" + currTimerMin, 580, 380);
    prevSelected = 8;
  }
  
   
  /*
  // For debugging 
  textSize(50);
  fill(127, 127, 127);
  text( "x:" + mouseX + "\n" + "y:" + mouseY, mouseX, mouseY); */
}

void mousePressed()
{
  // Buttons
  for (int i=1; i < buttons.length; i++)
  {
      if ((mouseX > buttons[i][0]) && (mouseX < buttons[i][0]+buttonX[i])
      && (mouseY > buttons[i][1]) && (mouseY < buttons[i][1]+buttonY[i]))
      {
        selected = i;
      }
  }
  
  // Cooking options
  for (int i=0; i < options.length; i++)
  {
      if ((mouseX > options[i][0]) && (mouseX < options[i][0]+optionX[i])
      && (mouseY > options[i][1]) && (mouseY < options[i][1]+optionY[i]))
      {
        optSelected = i;
      }
  }
  
  // Toast options
  for (int i=0; i < toastOpt.length; i++)
  {
      if ((mouseX > toastOpt[i][0]) && (mouseX < toastOpt[i][0]+toastX[i])
      && (mouseY > toastOpt[i][1]) && (mouseY < toastOpt[i][1]+toastY[i]))
      {
        toastSelected = i;
      }
  }
}