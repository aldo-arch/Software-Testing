<?php

declare(strict_types=1);

use PHPUnit\Framework\TestCase;

class ToodledoTest extends TestCase
{
    protected $driver;

    protected function setUp() : void
    {

        //You can get the key and secret here: https://testingbot.com/members/user/edit
        $key = 'klestihoxha3';
        $secret = 'DatGgvTHG6yrYsJPxax8';

        $testingBotApiUrl = "http://{$key}:{$secret}@hub-cloud.browserstack.com/wd/hub";

        $this->driver = new \Behat\Mink\Driver\Selenium2Driver('chrome',
            array("platform"=>"WINDOWS", "browserName"=>"chrome", "name" => "BehatTest"), $testingBotApiUrl);
    }
/*
    public function testSignup() : void
    {
        $session = new \Behat\Mink\Session($this->driver);
        $session->start();

        $session->visit("https://www.toodledo.com/signup.php");

        $page = $session->getPage();

        $page->fillField("fname", "MTS1819 February");

        $page->fillField("email", "test2.mts1819@mailinator.com");
        $page->fillField("pass1", "mts1819");

        $page->find("css", ".accept-cookies-button")->click();

        $page->find("css", "#register")->click();

        $this->assertTrue($session->getPage()->hasContent('test2.mts1819'));

        $session->stop();
    }
*/

    public function testAdd() : void
    {
        $session = new \Behat\Mink\Session($this->driver);
        $session->start();

        $session->visit("https://www.toodledo.com/signin.php");
        $page = $session->getPage();
        $page->fillField("email", "test2.mts1819@mailinator.com");
        $page->fillField("pass", "mts1819");

        $page->find("css", ".accept-cookies-button")->click();

        $page->find("css", "#signinbtn")->click();

        $session->visit("https://tasks.toodledo.com/main/");

        $session->getPage()->pressButton('nav_add');

        $session->getPage()->fillField("firstTitle", "test-task-mts1819");

        $session->getPage()->find("css", ".editNote")->setValue("test-note-mts1819: Here is a note");

        $session->getPage()->find('css', '.btn_c1')->click();

        $session->visit("https://tasks.toodledo.com/main/");

        $this->assertTrue($session->getPage()->hasContent('test-task'));

        $session->stop();
    }
}