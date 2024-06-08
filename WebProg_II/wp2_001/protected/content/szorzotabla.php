<br/>
<?php
    define('MIN_MERET', 1);
    define('MAX_MERET', 15);

    // 1) rendelkezik e a kérés P paraméterrel, amennyiben nem, akkor a default méret legyen 10*10
    if(filter_has_var(INPUT_GET, 'P')){
        $meret = filter_input(INPUT_GET, 'P', FILTER_VALIDATE_INT, 
                                [
                                    'options' => [
                                        'min_range' => MIN_MERET, 
                                        'max_range' => MAX_MERET
                                    ]                                
                                ]);
        if($meret === FALSE){
            header('Location: '.BASE_URL);
        }
          
    }
    else{
        $meret = 10;
    }
 ?>   
<h2>
    <?php if(MIN_MERET <= $meret-1):?>
    <a href="<?=BASE_URL.'start.php?E=szorzotabla&P='.$meret-1?>"> << </a> 
    <?php endif; ?>
    
         <?=$meret?> 
    <?php if($meret + 1 <= MAX_MERET): ?>
   <a href="<?=BASE_URL.'start.php?E=szorzotabla&P='.$meret+1?>"> >> </a>
   <?php endif; ?>
</h2>

<h2>Szorzótábla</h2>
<p>Az alábbiakban a(z) <?=$meret?>*<?=$meret?> méretű szorzótáblát látja. 
<h3>Natív ciklus segítségével</h3>
<table>
    <thead>
        <tr>
            <th></th>
            <?php for($i = 1; $i <= $meret; $i++): ?>
            <th><?=$i?></th>
            <?php endfor;?>
        </tr>
    </thead>
    <tbody>
        <?php for($i = 1; $i <= $meret; $i++): ?>
        <tr>
            <td><?=$i?></td>
            <?php for($j = 1; $j <= $meret; $j++): ?>
                <td><?=$i*$j?></td>
            <?php endfor;?>
        </tr>
        <?php endfor; ?>
    </tbody>
</table>
<h3>Tömb adatszerkezet segítségével</h3>
<?php 
$tabla = [];

$fejlec = [];

$fejlec[] = '';
for($i = 1; $i <= $meret; $i++)
    $fejlec[] = $i;

for($i = 1; $i <= $meret; $i++){
    $sor = [];
    $sor[] = $i;
    for($j = 1; $j <= $meret; $j++)
        $sor[] = $i * $j;
    $tabla[] = $sor;
}
?>
<table>
    <thead>
        <tr>
           <?php foreach($fejlec as &$mezo):?>
                <th><?=$mezo?></th>
           <?php endforeach; ?>
        </tr>
    </thead>
    <tbody>
        <?php $sorCnt = count($tabla); ?>
        <?php for($i = 0; $i < $sorCnt; $i++): ?>
            <tr>
                <?php $mezoCnt = count($tabla[$i]);?>
                <?php for($j = 0; $j < $mezoCnt; $j++): ?>
                    <td><?=$tabla[$i][$j]?></td>
                <?php endfor; ?>
            </tr>
        <?php endfor; ?>
    </tbody>
</table>
    