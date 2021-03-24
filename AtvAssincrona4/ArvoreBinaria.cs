using System;
using System.Collections.Generic;

namespace AtvAssincrona4
{
	class ArvoreBinaria
	{
		protected No raiz;

		public ArvoreBinaria()
		{
			this.raiz = null;
		}

		public void Exibir()
		{
			this.Exibir(raiz, 0);
			Console.WriteLine();
		}

		private void Exibir(No no, int nivel)
		{
			int i;

			if (no == null)
				return;

			Exibir(no.noDireito, nivel + 1);
			Console.WriteLine();

			for (i = 0; i < nivel; i++)
				Console.Write("    ");

			Console.WriteLine(no.info);

			Exibir(no.noEsquerdo, nivel + 1);
		}

		// pre-ordem
		public void PercorrerPreOrdem()
		{
			PercorrerPreOrdem(raiz);
			Console.WriteLine();
		}

		// pre-ordem
		private void PercorrerPreOrdem(No no)
		{
			if (no == null)
				return;
				  
			Console.Write(no.info + " ");
			
			PercorrerPreOrdem(no.noEsquerdo);
			PercorrerPreOrdem(no.noDireito);
		}

		// em ordem
		public void PercorrerEmOrdem()
		{
			PercorrerEmOrdem(raiz);
			Console.WriteLine();
		}

		// em ordem
		private void PercorrerEmOrdem(No no)
		{
			if (no == null)
				return;

			PercorrerEmOrdem(no.noEsquerdo);
			Console.Write(no.info + " ");
			PercorrerEmOrdem(no.noDireito);
		}

		// pos-ordem
		public void PercorrerPosOrdem()
		{
			PercorrerPosOrdem(raiz);
			Console.WriteLine();
		}

		// pos-ordem
		private void PercorrerPosOrdem(No no)
		{
			if (no == null)
				return;

			PercorrerPosOrdem(no.noEsquerdo);
			PercorrerPosOrdem(no.noDireito);
			Console.Write(no.info + " ");
		}

		// percurso ordenado por nivel
		public void PercorrerPorNivel()
		{
			if (raiz == null)
			{
				Console.WriteLine("arvore vazia");
			
				return;
			}

			Queue<No> q = new Queue<No>();
			q.Enqueue(raiz);

			No no;
			
			while (q.Count != 0)
			{
				no = q.Dequeue(); 
				Console.Write(no.info + " ");

				if (no.noEsquerdo != null)
					q.Enqueue(no.noEsquerdo);

				if (no.noDireito != null)
					q.Enqueue(no.noDireito);
			} 
			
			Console.WriteLine();
		}


		public int ObterAltura() 
		{
			return ObterAltura(raiz);
		}

		private int ObterAltura(No no) 
		{
			if (no == null)
				return 0;

			int alturaEsquerda = ObterAltura(no.noEsquerdo);
			int alturaDireita = ObterAltura(no.noDireito);

			if (alturaEsquerda > alturaDireita)
				return alturaEsquerda + 1;
			else
				return alturaDireita + 1;
		}

		public void CriarArvore()
		{
			raiz = new No('R');
			raiz.noEsquerdo = new No('E');
			raiz.noDireito = new No('D');
			raiz.noEsquerdo.noEsquerdo = new No('A');
			raiz.noEsquerdo.noDireito = new No('B');
			raiz.noDireito.noEsquerdo = new No('C');
		}

		public virtual void Inserir(char info)
		{
			if (this.raiz == null)
				this.raiz = new No(info);
			else
				this.Inserir(info, this.raiz);
		}

		// o(log n) arvore balanceada / o(n) -> arvores avl/rbt
		private void Inserir(char info, No no)
		{
			if (info < no.info)
			{
				if (no.noEsquerdo != null)
					this.Inserir(info, no.noEsquerdo);
				else
					no.noEsquerdo = new No(info);
			}
			else
			{
				if (no.noDireito != null)
					this.Inserir(info, no.noDireito);
				else
					no.noDireito = new No(info);
			}
		}

		public virtual void Remover(char info)
		{
			if (this.raiz != null)
				this.raiz = this.Remover(info, this.raiz);
		}

		public virtual No Remover(char info, No no)
		{
			if (no == null)
				return no;

			if (info < no.info)
				no.noEsquerdo = this.Remover(info, no.noEsquerdo);
			else if (info > no.info)
				no.noDireito = this.Remover(info, no.noDireito);
			else
			{
				No noTemp;

				if ((no.noEsquerdo == null) && (no.noDireito == null))
				{
					Console.WriteLine("removendo um no folha...");
					no = null;
					
					return no;
				}

				if (no.noEsquerdo == null) 
				{
					Console.WriteLine("removendo um no com um unico filho a direita...");
					noTemp = no.noDireito;
					//no = null;

					return noTemp;
				}

				if (no.noDireito == null)
				{
					Console.WriteLine("removendo um no com um unico filho a esquerda...");
					noTemp = no.noEsquerdo;
					//no = null;

					return noTemp;
				}

				Console.WriteLine("removendo um no com dois filhos...");
				noTemp = this.GetPredecessor(no.noEsquerdo);
				no.info = noTemp.info;
				no.noEsquerdo = this.Remover(noTemp.info, no.noEsquerdo);
			}

			return no;
		}
		
		public No GetPredecessor(No no)
		{
			if (no.noDireito != null)
				return this.GetPredecessor(no.noDireito);

			return no;
		}

		public char GetValorMinimo()
		{
			if (this.raiz != null)
				return this.GetValorMinimo(this.raiz);
			
			return raiz.info;
		}

		public char GetValorMinimo(No no)
		{
			if (no.noEsquerdo != null)
				return this.GetValorMinimo(no.noEsquerdo);
				
			return no.info;
		}

		public char GetValorMaximo()
		{
			if (this.raiz != null)
				return this.GetValorMaximo(this.raiz);

			return raiz.info;
		}

		public char GetValorMaximo(No no)
		{
			if (no.noDireito != null)
				return this.GetValorMaximo(no.noDireito);

			return no.info;
		}

	}
}