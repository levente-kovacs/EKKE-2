<?php require_once './protected/config/config.php'; ?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="<?=CHARSET?>">
        <title><?=TITLE?></title>
        
        <!-- <link rel="stylesheet" type="text/css" href="style.css"> -->
        
        <!-- csak akkor van szükségem a css link-re, hogy ha legalább egy elemet tartalmaz -->
        <?php if(!empty(CSS)){ // empty(): üres-e? 
            $css_item_count = count(CSS); // count hívás => tömb méretét adja meg 
            
            for($i = 0; $i < $css_item_count; $i++){
                echo '<link rel="stylesheet" type="text/css" href="'.CSS_DIR.CSS[$i].'">';
            }
                
        }?>
        
    </head>
    <body>
        <!-- elemei: fejléc, menu, tartalom, lábléc -->
        <?php // php blokk kezdete, ezt értelmezni kell!
           // echo '<p style="color:red">Hello World!</p>'; // = echo('Hello World!');
           // echo "<p style=\"color:red\">Hello World!</p>";
        /* php blokk vége, visszalépek "standard" működésbe*/?>
        
        <?php 
            // itt jelenjen meg a header tartalma => másoljuk ide a header.php tartalmát
            // include 'eleresi ut': behúzom a fájl tartamát, de ha nem létezik, akkor warningot kapok
            // require 'eleresi ut': behúzom a fájl tartalmát, de ha nem létezik, akkor fatalis hibat kapok
            // include_once 'eleresi ut': include + akkor töltöm be a fájlt, ha még az korábban nem történt meg
            // require_once 'eleresi ut': require + akkor töltöm be a fájlt, ha még az korábban nem történt meg
        ?>
        
        <?php include VIEWS_DIR.'header.php'; /*ha nics header, akkor csúnya, de dolgozni vele*/?>
        <?php require PROTECTED_DIR.'menu.php'; /*ha nincs menu, akkor kattintasra nem erem el a funkciokat*/?>
        <?php require PROTECTED_DIR.'content.php'; /* content nélkül nem akarok dolgozni, mert nem látom a kért tartalmat*/?>
        <?php include VIEWS_DIR.'footer.php'; /* csúnya nélküle az oldal, de funkcióját ellátja */?>        
    </body>
</html>