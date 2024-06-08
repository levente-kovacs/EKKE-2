<?php 
    // az E kulcshoz kell tartozni egy-egy fájlnak contetn almappában, amelynek a tartalmát 
    // meg kell jeleníteni

    // 1) nézzük meg, hogy van-e E kulcs a GET-es kérésben, ha nincs, akkor 
    // a kezdőoldalt jelenítjük meg 
    if(!filter_has_var(INPUT_GET, 'E')){
        $egyseg = START_CONTENT;
    }
    else{
        $egyseg = filter_input(INPUT_GET, 'E',FILTER_SANITIZE_STRING);
    }
    
    $egysegEleres = CONTENT_DIR.$egyseg.'.php';
    
    if(!file_exists($egysegEleres)){
       header('Location: '.BASE_URL); 
    }
    
    require_once $egysegEleres;

?>