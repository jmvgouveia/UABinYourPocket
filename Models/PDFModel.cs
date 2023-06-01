using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf.Advanced;


namespace TesteASP.Models
{
    public class PDFController : Controller
    {
        //TODO: Completar
        /*
        public static PdfDocument? GerarDocumento()
        {
            GerarCabecalho();
            GerarRodape();

            return null;
        }

        private static void GerarCabecalho()
        {

        }

        private static void GerarRodape()
        {

        }*/
        public async Task<IActionResult> GerarPdfComNotas()

        {

            var ucs = new List<DadosUCS>
        {
        new DadosUCS("Renato Sanches", "IIA", "17"),
        new DadosUCS("Renato Sanches","Matemática Finita", "14"),
        new DadosUCS("Renato Sanches", "Laboratório de Desenvolvimento", "20")

        };



            // Cria um novo documento PDF
            var document = new PdfDocument();

            // Adiciona uma nova página
            var page = document.AddPage();

            // Define o tamanho da página para A4
            page.Size = PageSize.A4;

            // Cria um objeto de gráficos
            var gfx = XGraphics.FromPdfPage(page);

            // Define o caminho para o arquivo de logotipo
            var logoPath = "logo.png";
            // Carrega o logotipo como uma imagem
            var logoImage = XImage.FromFile(logoPath);
            // Define a posição e o tamanho do logotipo na página
            var logoWidth = 100;
            var logoHeight = 100;
            // Calcula a posição X para centralizar o logotipo
            var logoX = (page.Width - logoWidth) / 2;
            var logoY = 50; // Define a posição Y conforme necessário
            // Desenha o logotipo na página
            gfx.DrawImage(logoImage, logoX, logoY, logoWidth, logoHeight);



            // Define a fonte do texto
            XFont fontNormal = new XFont("Arial", 10, XFontStyle.Regular);
            XFont fontBold = new XFont("Arial", 10, XFontStyle.Bold);





            // Define a posição inicial do título
            var titleX = 50;
            var titleY = logoY + logoHeight + 20;


            // Define a posição inicial dos dados
            var x = 100;
            var y = 200;


            // Define a largura total da tabela
            var tableWidth = 300;

            // Define a altura da célula
            var cellHeight = fontNormal.Height * 2.5;

            gfx.DrawString("Nome:", fontNormal, XBrushes.Black, new XPoint(titleX, titleY));

            // Desenha o nome na página
            gfx.DrawString(ucs[0].NomeAluno, fontBold, XBrushes.Black, new XPoint(x, titleY));

            gfx.DrawString("Notas das disciplinas em que estou inscrito :", fontNormal, XBrushes.Black, new XPoint(x, y));

            y += (int)(cellHeight * 3);

            for (int i = 0; i < ucs.Count; i++)
            {
                var yPos = y + (i + 1) * cellHeight;

                gfx.DrawString(ucs[i].Nome, fontNormal, XBrushes.Black, new XPoint(x, yPos));
                gfx.DrawString(ucs[i].Nota, fontNormal, XBrushes.Black, new XPoint(page.Width - 100, yPos));

                if (i < ucs.Count - 1)
                {
                    // Desenhar o separador
                    var separatorY = yPos + cellHeight * 0.4; // Posição vertical do separador
                    var separatorX1 = x; // Posição horizontal inicial do separador (esquerda)
                    var separatorX2 = page.Width - 90; // Posição horizontal final do separador (direita)

                    gfx.DrawLine(XPens.Black, separatorX1, separatorY, separatorX2, separatorY);
                }
            }



            // Define a mensagem do rodapé
            var footerMessage = "While (True) Cry 2023;";
            // Define a posição do rodapé
            var footerX = 50;
            var footerY = page.Height - 50; // Ajuste a posição vertical conforme necessário
            // Desenha a mensagem do rodapé
            gfx.DrawString(footerMessage, fontNormal, XBrushes.Black, new XPoint(footerX, footerY));


            // Salva o documento em um arquivo
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            // Retorna o stream como um arquivo para download
            stream.Position = 0;
            return File(stream, "application/pdf", "hello1.pdf");

        }
        public class DadosUCS

        {
            public string NomeAluno { get; set; }
            public string Nome { get; set; }
            public string Nota { get; set; }


            public DadosUCS(string nomealuno, string nome, string nota)
            {
                NomeAluno = nomealuno;
                Nome = nome;
                Nota = nota;

            }
        }



    }
}
        

