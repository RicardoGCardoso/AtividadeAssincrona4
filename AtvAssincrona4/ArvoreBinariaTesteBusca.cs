using System;
using System.Collections.Generic;
using System.Text;

namespace AtvAssincrona4
{
    class ArvoreBinariaTesteBusca : ArvoreBinaria
    {
        public void buscarTeste(char info)
        {
            buscarTeste(info, raiz);
        }

        private void buscarTeste(char info, No no)
        {
            if (no == null)
                return;
            if (no.info == info)
                return;
            if(info > no.info)
                buscarTeste(info, no.noDireito);
            else
                buscarTeste(info, no.noEsquerdo);
        }
    }
}
