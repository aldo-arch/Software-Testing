<?php
require 'vendor/autoload.php';
require 'u1.php';

if(!empty($_POST["money"])){
	$method = $_POST["money"];
	 $c = new Container();
 $c->addImpl("GatewayPayment", $method);
 $ml = $c->getInstance("OrderProcess");
$bmv = $ml->test();

}

?>
<!DOCTYPE html>
<html>
<head></head>
<body>
	
<form action="index.php" method="POST">
	<input type="radio" name="money"  value="PayCash" >Cash
	<input type="radio" name="money"  value="PayCreditCard" >Pay Credit Card
	<input type='submit'>
</form>
</body>
</html>