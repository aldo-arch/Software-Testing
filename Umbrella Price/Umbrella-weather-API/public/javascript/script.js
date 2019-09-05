
//Vendosim nëse do të ndryshojmë çmimet
//çdo disa sekonda apo kur përdoruesi të 
//bëjë reload aplikacionit në web
window.onload=GetForecast
//$(document).ready(
	//Në rastin e reload mjafton të thërrasim vetëm funksionin
	//e çkomentojmë pjesën poshtë.

	//GetForecast()

	//Në rastin kur duam që çmimet të ndryshojnë automatikisht (pra që mos të kemi reload)
	//komentojmë pjesën sipër dhe përdorim kodin më poshtë.
// setInterval(function(){
// GetForecast();
// },5000 ));
	//Pra në rastin tonë kjo kryhet çdo pesë sekonda.

	//Fillimisht kryejmë lidhjen me URL nga ku do të marrim informacionin mbi motin aktual	
 function GetForecast(){
 var APIid = "f7ee5eed1169d1ec2e4b4d00902a7644"
 var raisePrice=0; //Shërben si një variabël 'Boolean' që do të na shërbejë
 				   //për të ndryshuar çmimin më pas
 $.ajax({
 method: "GET",
 url:"http://api.openweathermap.org/data/2.5/weather/?APPID="+APIid,
 dataType: "json",
 data:{q:"Tirana"},//Kemi marrë në shqyrtim vetëm një qytet

 //Në rastin kur lidhja realizohet me sukses
 success:function(data)
 {console.log(data);
  var weather=data.weather[0].main //Për të ndryshuar çmimin e çadrave jemi bazuar në 'Weather-Main'
 	  							  // Pra mjafton që elementi i marrë të tregojë re(clouds),shi(rain) apo dhe borë(snow)
 	  							  //Për të parë edhe një ndryshim konkret mund të modifikojmë kodin pra të
 	  							  //kontrollojmë nëse nuk ka re,shi apo borë
 	if(weather.toUpperCase() == "CLOUDS" || weather.toUpperCase() == "RAIN"  || weather.toUpperCase() == "SNOW" )
 		{raisePrice=1} //Në këtë rast variabli ndihmës (i përmendur më sipër) na ndihmon për të rritur çmimin

 		//Realizojmë ndryshimin e çmimit (duhet parë skedari app.js)
 		$.ajax({
 			method:"GET",
 			url:"http://localhost:3000/changeALLprices/"+raisePrice,
 			datatype:"html",
 			//Në rast suksesi, afishojmë të dhënat e reja (çmimin e ri) për elementët aktualë
 			success:function(data){
 				$("#cadrat").html(data)}, //Duhet parë skedari index.ejs
 			//Në rast 'error-i' apo gabimi, afishojmë një mesazh, dhe nuk realizojmë veprime	
 			error:function(error){
 				alert("Whoops!Ndodhi nje gabim.")}
 		})}
		})
 //Në rastin tjetër (ndryshe nga më sipër ku lidhja u realizua me sukses), afishojmë një mesazh gabimi
 //dhe nuk kryejmë veprime
.fail(function(err){
	alert("Cannot get data from API")
})}
