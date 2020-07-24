namespace univo.custom
{
    public interface permisos
    {
        int visualizar(){
              return 0;
        }
        int crear(){
            return 1;
        }
        int editar(){
            return 2;
        }
        int actualizar(){
            return 3;
        }
        int eliminar(){
            return 4;
        }
        int imprimir(){
            return 5;
        }


    }
}