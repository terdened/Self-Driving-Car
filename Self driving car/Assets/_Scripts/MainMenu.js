//Меню

var Play = false;
var Settings = false;
var Author = false;
var Quit = false;
//Меню настроек
var Back = false;

//Графика
var Low = false;
var Medium = false;
var High = false;
var Fantastic = false;
var BackM = false;

var Day= false;
var Night = false;

function OnMouseEnter() {
    GetComponent.<Renderer>().material.color = Color.blue;
}


function OnMouseExit() {
    GetComponent.<Renderer>().material.color = Color.white;
}

function OnMouseUp() {
    if (Play == true) {
        Application.LoadLevel(4);
    }
    if(Settings == true) {
        Application.LoadLevel(3);
    }


    if (Author == true) {
        Application.LoadLevel(5);
    }

    if (Quit == true) {
        Application.Quit();
    }
    if(Back == true) {
        Application.LoadLevel(0);
    }

    if(Low == true){
        QualitySettings.currentLevel = QualityLevel.Simple;
    }

    if(Medium == true){
        QualitySettings.currentLevel = QualityLevel.Good;
    }

    if(High == true){
        QualitySettings.currentLevel = QualityLevel.Beautiful;
    }

    if(Fantastic == true){
        QualitySettings.currentLevel = QualityLevel.Fantastic;
    }

    //
    if(BackM == true) {
        Application.LoadLevel(0);
    }
    if(Day == true) {
        Application.LoadLevel(1);
    }
    if(Night == true) {
        Application.LoadLevel(2);
    }
}
