# FUNCION

**powershell**: 
- iniciarliza entorno
    - carga .cs
    - automatiza carga de xaml (vista)
- ejecuta componentes 
    - encargados de uso enlazar view y viewmodels

**C#**
- declaracion de viewmodels
    - encargado de binding de datos
    - encargado de coordinacion de bindings
- declarcion de modelos
    - encargado de registro de datos

**XAML**
- vista del sistema
    - diseño declarativo
    - binding de inputs con viewmodel
    - uso de comandos

# SECCIONES
bootstrap (ps1) => component(ps1) => viewmodel (cs) => model (cs)

component(ps1) => viewmodel (cs) => model (cs)

component(ps1) => view (xaml)

             
# FLUJO

1. MainComponent (ps1)
    - carga la ventana inicial (xaml)
    - genera model de configuracion (cs)
    - instancia componente de cada subventana