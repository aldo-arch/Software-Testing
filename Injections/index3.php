<?php
require 'vendor/autoload.php';
require 'u2.php';

if(!empty($_POST["money"])){
	$method = $_POST["money"];
	 $c = new Container();
 $c->addImpl("GatewayPayment", ["PayCash","PayCreditCard","PayDebit","PayCheque"]);
 $ml = $c->getInstanceByCriteria("OrderProcess",$method);
$bmv = $ml->test();

}


?>
<!DOCTYPE html>
<html>
<head></head>
<body>
	
<form action="index3.php" method="POST">
	<input type="radio" name="money"  value="PayCash" >Cash
	<input type="radio" name="money"  value="PayCreditCard" >Pay Credit Card
	<input type="radio" name="money"  value="PayDebit" >Pay by Debit Card
	<input type="radio" name="money"  value="PayCheque" >Pay by Cheque
	<input type='submit'>
</form>
</body>
</html>