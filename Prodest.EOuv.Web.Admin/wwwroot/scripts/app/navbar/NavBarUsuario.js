const NavBarUsuario = {

    name: 'NavBarUsuario',

    template: '#nav-bar-usuario-template',
  
    methods: {

        trocarAparencia() {
            if (document.body.classList.contains("dark-mode")) {
                document.body.classList.remove("dark-mode");
                document.cookie = "user.aparencia=light";
            }
            else {
                document.body.classList.add("dark-mode");
                document.cookie = "user.aparencia=dark";
            }
        }
    }
}