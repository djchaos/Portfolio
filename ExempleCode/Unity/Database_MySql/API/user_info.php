<?php
    $result = 'Error 403 - Forbidden';
    
    if(isset($_GET['token'])) {
        if(isset($_GET['id'])) {
            if(is_numeric($_GET['id'])) {
                include_once('lib/database_manager.php');
                $database = new DatabaseManager('api');
                $token = $_GET['token'];
                $expiration = $database->SqlExecute("SELECT expiration FROM api.token WHERE value='{$token}'");

                if(!empty($expiration)) {
                    if($expiration[0]['expiration'] > time()) {
                        $count = intval($_GET['count']);
                        $userinfo = $database->SqlExecute("SELECT id, username, highscore, email FROM api.user WHERE id= {$id};");
                        $result = json_encode($vScore);
                        }
                    }
                }
            }
        }
    }

    print_r($result);die;
?>