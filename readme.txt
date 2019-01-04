SQL

create user 'admin'@'%' identified by '12345678';
grant all privileges on *.* to 'admin'@'%' with grant option;
flush privileges;

DOCKER

check ip a container
ocker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' e74c57ea8d32