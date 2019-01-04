
############################
###   Install Command    ###
############################
alias sagi='sudo apt-get install'
alias sagr='sudo apt-get remove'
alias sagu='sudo apt-get update && sudo apt-get upgrade'


############################
###   Docker Command     ###
############################
alias drm='docker rm'
alias drmi='docker rmi'
alias dgetip="docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}'"