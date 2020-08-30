using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android;

namespace alcoo_VS_gasolina
{
    [Activity(Label = "Alcool VS Gasolina" , MainLauncher = true, Icon = "@drawable/Etanol_VS")]
    public class MainActivity : Activity
    {
        public Decimal valor_etanol, valor_gasolina, resultado;
        EditText edt_valor_etanol;
        EditText edt_valor_gasolina;
        Button btnCalcular;
        Button btnLimpar;
        ImageButton btnDica;
   
        TextView txtMensagem_do_resultado;
        TextView txtmostra_valor_etanol;
        TextView txtmostra_valor_gasolina;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            edt_valor_etanol = FindViewById<EditText>(Resource.Id.edt_valor_etanol);
            edt_valor_gasolina = FindViewById<EditText>(Resource.Id.edt_valor_gasolina);
            btnCalcular = FindViewById<Button>(Resource.Id.btnCalcular);
            txtMensagem_do_resultado = FindViewById<TextView>(Resource.Id.txtMensagem_do_resultado);
            txtmostra_valor_etanol = FindViewById<TextView>(Resource.Id.txtmostra_valor_etanol);
            txtmostra_valor_gasolina = FindViewById<TextView>(Resource.Id.txtmostra_valor_gasolina);
            btnLimpar = FindViewById<Button>(Resource.Id.btnLimpar);
            btnDica = FindViewById<ImageButton>(Resource.Id.btnDica);
    

            btnCalcular.Click += BtnCalcular_Click;
            btnLimpar.Click += BtnLimpar_Click;
            btnDica.Click += BtnDica_Click;
        
        }

        private T FindViewById<T>(object edt_valor_etanol)
        {
            throw new NotImplementedException();
        }

        public void BtnCalcular_Click(object sender, System.EventArgs e)
        {
        
            try
            {
                valor_etanol = Decimal.Parse(edt_valor_etanol.Text);
                valor_gasolina = Decimal.Parse(edt_valor_gasolina.Text);
               
              
                resultado = (valor_etanol / valor_gasolina);  
                if (Double.Parse(resultado.ToString()) < 0.7)
                {
                    txtMensagem_do_resultado.Text = "O Resultado foi :  " +
                    Math.Round(resultado, 2).ToString() +
                    "         \n\n" + "Melhor Abastecer com Etanol !";
            
                    AlertDialog.Builder mostravariavel = new AlertDialog.Builder(this);
                    mostravariavel.SetTitle("O valor do resultado");
                    mostravariavel.SetMessage(Math.Round(resultado, 2).ToString());
                    mostravariavel.Show();

                }
                else
                {
                    txtMensagem_do_resultado.Text = "O Resultado foi :  " +
                   Math.Round(resultado, 2).ToString()
                    + "       \n\n " + "Melhor Abastecer com Gasolina !";
                    txtMensagem_do_resultado.AutoSizeTextType.ToString();
                    AlertDialog.Builder mostravariavel = new AlertDialog.Builder(this);
                    mostravariavel.SetTitle("O valor do resultado");
                    mostravariavel.SetMessage(Math.Round(resultado, 2).ToString());
                    mostravariavel.Show();

                } 
            }
            catch
                {
                    if(edt_valor_etanol.Text == "" || edt_valor_gasolina.Text =="")
                    {
                        txtMensagem_do_resultado.Text = "Favor preencher todos os campo";
                    AlertDialog.Builder alerta_campo_vazio = new AlertDialog.Builder(this);
                    alerta_campo_vazio.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                    alerta_campo_vazio.SetTitle("ATENÇÂO !");
                    alerta_campo_vazio.SetMessage("Ao menos um dos campos está vazio, favor verificar!");
                    alerta_campo_vazio.Show();
                    edt_valor_etanol.RequestFocus();

                }
                };
        }
   
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                edt_valor_etanol.Text = "";
                edt_valor_gasolina.Text = "";
                txtMensagem_do_resultado.Text = "Resultado.";
                txtMensagem_do_resultado.SetTextColor(GetColorStateList(1520));  
                edt_valor_etanol.RequestFocus();

            }
            catch
            {
                throw new NotImplementedException();
            };
        }
        private void BtnDica_Click(object sender, EventArgs e)
        {
            try
            {
                AlertDialog.Builder Dica = new AlertDialog.Builder(this);
                Dica.SetTitle("Dica !");
                Dica.SetIcon(Android.Resource.Drawable.IcMenuDirections);
                Dica.SetMessage("Favor usar virgula para separação decimal \n\n" +
                    "Para esvaziar os campos clique no botão limpar ");
                Dica.Show();
            }
            catch
            {
                throw new NotImplementedException();
            };

        }

    }
}

