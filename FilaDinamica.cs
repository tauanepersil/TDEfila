namespace TDE
{
	public class FilaDinamica : IFila<string>
	{
		public int Tamanho { get; private set; }
		public No<string>? Inicio { get; private set; }
		public No<string>? Fim { get; private set; }

		public FilaDinamica()
		{
			Tamanho = 0;
			Inicio = null;
			Fim = null;
		}

		public No<string> Desenfilerar()
		{
			if (EstaVazia()) throw new Exception("Underflow");

			var valorRetorno = Inicio;
			
			Inicio = Inicio.ProximoNo;
			Tamanho--;
			return valorRetorno;
		}

		public void Enfilerar(string item)
		{
			var novoNo = new No<string>(item, null);
			if (EstaVazia())
				Inicio = novoNo;
			else
				Fim.AtualizarNoProximo(novoNo);
			Fim = novoNo;
			Tamanho++;
		}

		public bool EstaVazia() => Tamanho == 0;
	}
}