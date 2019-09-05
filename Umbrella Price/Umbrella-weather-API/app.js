
//Për përdorimin e mongoose
var express = require("express");
var app = express();
var bodyParser = require("body-parser");
var mongoose = require("mongoose");
var methodOverride = require("method-override")
//lidhja me bazën e të dhënave
mongoose.connect("mongodb://localhost/D3_project");
app.set("view engine", "ejs");
app.use(express.static("public"));
app.use(bodyParser.urlencoded({extended: true}));
app.use(methodOverride("_method"));

//Mongoose/model config
var cadraSchema = new mongoose.Schema({
    name: String,
    description: String,
    type: String,
    //Cmimi aktual i rritur me 100 në rast shiu,bore apo kur ka re
    rainprice:Number,
    //Cmimi aktual
    price: Number,
    //Cmimi origjinal
    originalprice:Number,
    //Historiku i ndryshimit të çmimeve
    price_changes: {changeDate: Date, oldPrice: Number}
});

var Cadra = mongoose.model("Cadrat", cadraSchema);

//Restful routs
//Për path-in e faqes kryesore
app.get("/", function(req, res) {
    res.redirect("/cadrat");
});

//INDEX ROUTE
//Faqja kryesore
app.get("/cadrat", function(req, res){
    Cadra.find({}, function(err, cadrat){
        if(err){
            console.log(err);
        }else{
             res.render("index",{cadrat:cadrat});}
    });
    });


//NEW ROUTE
//Path-i për krijimin e çadrave të reja
app.get("/cadrat/new", function(req, res) {
   res.render("new");
});

//CREATE ROUTE
app.post("/cadrat", function(req, res){
	var obj =req.body.data
  //Ndryshimi i çmimit
	obj.rainprice=parseInt(obj.price)+100
	obj.originalprice=parseInt(obj.price)
  Cadra.create(obj, function(err, newCader){
      if(err){
          res.render("new");
      }else{
          res.redirect("/cadrat");}
   });
   });

//SHOW ROUTE
//Në rastin kur duam të modifikojmë apo të fshijmë elementë
//Fillimisht duhet të kemi klikuar mbi emrin e elementit që do të modifikojmë
app.get("/cadrat/:id", function(req, res) {
    Cadra.findById(req.params.id, function(err, foundCader){
        if(err){
            res.redirect("/cadrat");
        }else{
            res.render("show", {cadra: foundCader});}
  });
  });

//EDIT ROUTE
//Path-i për modifikim
app.get("/cadrat/:id/edit", function(req, res) {
    Cadra.findById(req.params.id, function(err, foundCader){
        if(err){
            res.redirect("/cadrat");
        }else{
            res.render("edit", {cadra: foundCader});}
  });
  });

//UPDATE ROUTE
//Modifikimi i elementit
app.put("/cadrat/:id", function(req, res){
	var obj =req.body.data
  //Cmimi aktual rritet me 100 lekë
	obj.rainprice=parseInt(obj.price)+100
	obj.originalprice=parseInt(obj.price)
    Cadra.findByIdAndUpdate(req.params.id, obj, function(err, updatedCadra){
        if(err){
        res.redirect("/cadrat");
        }else{
        res.redirect("/cadrat/" + req.params.id);}
  });
  });

//DELETE ROUTE
//Pathi për fshirje të elementit
app.delete("/cadrat/:id", function(req, res){
   Cadra.findByIdAndRemove(req.params.id, function(err){
       if(err){
           res.redirect("/cadrat");
       }else{
           res.redirect("/cadrat");}
  });
  });

//Për historikun e ndryshimit të çmimeve
app.get("/changeALLprices/:raisePrice",function(req,res){
	   var today = new Date();
     //Variabli ndihmës raisePrice
	   var raisePrice=req.params.raisePrice;
Cadra.find({},function(error,data)
{ 
  //Për çdo element nëse ka rritje çmimi, do ndryshojë çmimi
	data.forEach(function(element)
	{ var newprice=0;
if(raisePrice==1)
   {
   	newprice=parseInt(element.rainprice);}
   else{
    newprice=parseInt(element.originalprice);}
   
   var oldprice=element.price;
   var id=element._id;
   //Për datën dhe çmimin
   var obj ={
   	changeDate: today,
   	oldPrice: oldprice};
   //Nëse ka ndryshim çmimi
   if(newprice!=oldprice)
     {Cadra.update(
	   {_id:id},
	   {price:newprice,
		  $push:{price_changes:obj} 
	   },

  //Afishimi i mesazheve në terminal 'node app.js'
	function(err,data){
	console.log(data)
	if(err){
		console.log(err)
		}else {
	console.log('Done')	}
  })}
  })
  })

Cadra.find({},function(err,cadrat)
{
  res.render("index",{cadrat:cadrat});
})

})

//Afishimi i mesazhit në terminal (për informim të lidhjes me sukses)
//Porta e përdorur : 3000
app.listen(3000, function(){
    console.log("server has started");
});
