<?php
require 'vendor/autoload.php';
require 'u2.php';

$c = new Container();
$c->addImpl("GatewayPayment", ["PayCash","PayCreditCard","PayDebit","PayCheque"]);
$ml = $c->getInstance("OrderProcess");
$bmv = $ml->test();

?>
