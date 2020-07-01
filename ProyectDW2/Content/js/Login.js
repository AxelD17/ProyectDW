var btnIngresar = document.getElementById("btnIngresar");
btnIngresar.onclick = function () {
    //voz("Bienvenido al sistema");
}



function voz(mensaje) {
    var vozHablar = new SpeechSynthesisUtterance(mensaje);
    window.speechSynthesis.speak(vozHablar);
}