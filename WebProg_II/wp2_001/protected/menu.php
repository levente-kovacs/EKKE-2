<?php  // menu szerkezet definiálása 
    $menu = [
       [
           'href' => BASE_URL.'start.php?E=szorzotabla', 
           'title' => 'Szorzótábla', 
           'extra' => ['target' => '_blank']
       ],
       [
           'href'   =>  '#',
           'title'  =>  'Egyetemek',
           'extra'  =>  [ 'style' => 'color:red;', 'target' => '_blank'], 
           'childs' =>  [
               [
                   'href'   =>  '#',
                   'title'  =>  'Magyar egyetemek',
                   'childs' =>  [
                       [
                           'href'   =>  'http://uni-eszterhazy.hu',
                           'title'  =>  'EKE', 
                           'extra'  =>  ['target' => '_blank']
                       ],
                       [
                           'href'   =>  'http://uni-miskolc.hu',
                           'title'  =>  'ME'
                       ]
                   ]
               ]
           ]
       ]
    ];
    require_once CORE_DIR.'views.php';
    print_menu($menu);
 
?>

<?php // menu szerkezet megjelenítése 
/*
    $menuCnt = count($menu); // lekérdezem a menu tömb elemszámát 
    for($i = 0; $i < $menuCnt; $i++):?>
        <?php 
            $extraString = '';
            if(array_key_exists('extra', $menu[$i])){
                foreach($menu[$i]['extra'] as $key => $value)
                    $extraString = $extraString.' '.$key.'="'.$value.'"';
            }
        ?>
        <a href="<?=$menu[$i]['href']?>" <?=$extraString?>>
            <?=$menu[$i]['title']?>
        </a>
    <?php endfor; */?>