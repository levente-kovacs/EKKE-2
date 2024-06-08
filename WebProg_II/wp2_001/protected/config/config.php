<?php

// alapvető konfiugráció a PHP keretünknek, erre fogunk hivatkozni az "építkezés" során 


define('CHARSET','utf-8');
define('TITLE','Árvíztűrő tükörfúrógép');
define('CSS',['style.css', 'menu_style.css']); // [] = array()


// konstansokat definiálunk, hogy azokat futás közben ne lehessen megváltoztatni:
// define(konstansnév, konstansérték);
define('ROOT_DIR','./');
define('PROTECTED_DIR',ROOT_DIR.'protected/');
define('PUBLIC_DIR',ROOT_DIR.'public/');
define('VIEWS_DIR',PROTECTED_DIR.'views/');
define('CSS_DIR', PUBLIC_DIR.'css/');
define('CORE_DIR', PROTECTED_DIR.'core/');
define('CONTENT_DIR', PROTECTED_DIR.'content/');

define('START_CONTENT', 'main');

define('BASE_URL','http://localhost/wp2_001/');