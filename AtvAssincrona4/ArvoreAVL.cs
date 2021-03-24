using System;
using System.Collections.Generic;
using System.Text;

namespace AtvAssincrona4
{
    class ArvoreAVL : ArvoreBinaria
    {

        public ArvoreAVL()
        {

        }

        public override void Inserir(char info)
        {
            if (this.raiz == null)
                this.raiz = new No(info);
            else
                this.raiz = InserirAVL(info, raiz);
        }

        private No InserirAVL(char info, No atual)
        {
            No novo = new No(info);
            if (atual == null)
            {
                atual = novo;
                return atual;
            }
            else if (novo.info < atual.info)
            {
                atual.noEsquerdo = InserirAVL(info, atual.noEsquerdo);
                atual = BalancearArvore(atual);
            }
            else if (novo.info > atual.info)
            {
                atual.noDireito = InserirAVL(info, atual.noDireito);
                atual = BalancearArvore(atual);
            }
            return atual;
        }

        public override void Remover(char info)
        {
            if (this.raiz != null)
                this.raiz = this.Remover(info, this.raiz);
        }

        public override No Remover(char info, No SubArvore)
        {
            No NoPai;
            if (SubArvore == null) // CASO A SUBARVORE SEJA NULA
            { 
                return null; 
            }
            else
            {
                // PERCORRE RECURSIVAMENTE PARA CASOS EM QUE O VALOR SEJA MENOR QUE O RAIZ DA SUBARVORE
                if (info < SubArvore.info)
                {
                    SubArvore.noEsquerdo = Remover(info, SubArvore.noEsquerdo);
                    if (FatorDeBalanceamento(SubArvore) == -2)//here
                    {
                        if (FatorDeBalanceamento(SubArvore.noEsquerdo) <= 0)
                        {
                            SubArvore = RotacaoDireitaDireita(SubArvore);
                        }
                        else
                        {
                            SubArvore = RotacaoDireitaEsquerda(SubArvore);
                        }
                    }
                }
                // PERCORRE RECURSIVAMENTE PARA CASOS EM QUE O VALOR SEJA MAIOR QUE O RAIZ DA SUBARVORE
                else if (info > SubArvore.info)
                {
                    SubArvore.noEsquerdo = Remover(info, SubArvore.noEsquerdo);
                    if (FatorDeBalanceamento(SubArvore) == 2)
                    {
                        if (FatorDeBalanceamento(SubArvore.noEsquerdo) >= 0)
                        {
                            SubArvore = RotacaoEsquerdaEsquerda(SubArvore);
                        }
                        else
                        {
                            SubArvore = RotacaoEsquerdaDireita(SubArvore);
                        }
                    }
                }
                // CASO O VALOR SER DELETA SEJA IGUAL AO VALOR DO NÓ ATUAL
                else
                {
                    if (SubArvore.noEsquerdo != null)
                    {
                        // PERCORRE PELO NÓ ESQUERDO PARA POR COMO SUCESSOR
                        NoPai = SubArvore.noEsquerdo;
                        while (NoPai.noEsquerdo != null)
                        {
                            NoPai = NoPai.noEsquerdo;
                        }
                        SubArvore.info = NoPai.info;
                        SubArvore.noEsquerdo = Remover(info, SubArvore.noEsquerdo);
                        // REALIZA O REBALACEAMENTO
                        if (FatorDeBalanceamento(SubArvore) == 2)
                        {
                            if (FatorDeBalanceamento(SubArvore.noEsquerdo) >= 0)
                            {
                                SubArvore = RotacaoEsquerdaEsquerda(SubArvore);
                            }
                            else { SubArvore = RotacaoEsquerdaDireita(SubArvore); }
                        }
                    }
                    else
                    {
                        return SubArvore.noEsquerdo;
                    }
                }
            }
            return SubArvore;
        }

        private int FatorDeBalanceamento(No atual)
        {
            int AlturaNoEsquerda = AlturaSubArvore(atual.noEsquerdo);
            int AlturaNoDireita = AlturaSubArvore(atual.noDireito);
            int fator = AlturaNoEsquerda - AlturaNoDireita;
            return fator;
        }

        private No BalancearArvore(No atual)
        {
            int CalcularFator = FatorDeBalanceamento(atual);
            if (CalcularFator > 1)
            {
                if (FatorDeBalanceamento(atual.noEsquerdo) > 0)
                {
                    atual = RotacaoEsquerdaEsquerda(atual);
                }
                else
                {
                    atual = RotacaoEsquerdaDireita(atual);
                }
            }
            else if (CalcularFator < -1)
            {
                if (FatorDeBalanceamento(atual.noDireito) > 0)
                {
                    atual = RotacaoDireitaEsquerda(atual);
                }
                else
                {
                    atual = RotacaoDireitaDireita(atual);
                }
            }
            return atual;
        }

        private int MaiorAltura(int TEsquerda, int TDireita)
        {
            if (TEsquerda > TDireita)
                return TEsquerda;
            else
                return TDireita;
        }

        private int AlturaSubArvore(No atual)
        {
            int Altura = 0;
            if (atual != null)
            {
                int AlturaNoEsquerda = AlturaSubArvore(atual.noEsquerdo);
                int AlturaNoDireita = AlturaSubArvore(atual.noDireito);
                int Maior = MaiorAltura(AlturaNoEsquerda, AlturaNoDireita);
                Altura = Maior + 1;
            }
            return Altura;
        }

        private No RotacaoDireitaDireita(No subArvore)
        {
            No NoRaizSubArvore = subArvore.noDireito;
            subArvore.noDireito = NoRaizSubArvore.noEsquerdo;
            NoRaizSubArvore.noEsquerdo = subArvore;
            return NoRaizSubArvore;
        }
        private No RotacaoEsquerdaEsquerda(No parent)
        {
            No NoRaizSubArvore = parent.noEsquerdo;
            parent.noEsquerdo = NoRaizSubArvore.noDireito;
            NoRaizSubArvore.noDireito = parent;
            return NoRaizSubArvore;
        }
        private No RotacaoEsquerdaDireita(No parent)
        {
            No NoRaizSubArvore = parent.noEsquerdo;
            parent.noEsquerdo = RotacaoDireitaDireita(NoRaizSubArvore);
            return RotacaoEsquerdaEsquerda(parent);
        }
        private No RotacaoDireitaEsquerda(No parent)
        {
            No NoRaizSubArvore = parent.noDireito;
            parent.noDireito = RotacaoEsquerdaEsquerda(NoRaizSubArvore);
            return RotacaoDireitaDireita(parent);
        }

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
            if (info > no.info)
                buscarTeste(info, no.noDireito);
            else
                buscarTeste(info, no.noEsquerdo);
        }
    }
}
