<?php
    $result = 'Error 403 - Forbidden';
    
    if(isset($_GET['token'])) {
        if(isset($_GET['count'])) {
            if(is_numeric($_GET['count'])) {
                include_once('lib/database_manager.php');
                $database = new DatabaseManager('api');
                $token = $_GET['token'];
                $expiration = $database->SqlExecute("SELECT expiration FROM api.token WHERE value='{$token}'");

                if(!empty($expiration)) {
                    if($expiration[0]['expiration'] > time()) {
                        $count = intval($_GET['count']);
                        if($count > 0) {
                            $vScore = $database->SqlExecute("SELECT username, highscore FROM api.user ORDER BY highscore DESC LIMIT {$count};");
                            $result = json_encode($vScore);
                        }
                    }
                }
            }
        }
    }

    print_r($result);die;
?>