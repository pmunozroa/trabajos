using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using proyecto_casino.Models.persona;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace proyecto_casino.Views
{
    public partial class MainWindow : Window
    {
        Random random = new Random();


        int saldo = 1000;
        int apuestaActualBJ = 0;

        int cuentaJugador = 0;
        int cuentaCrupier = 0;
        bool juegoActivoBJ = false;
        bool invitado = false;
        List<Cliente> usuarios = new List<Cliente>
        {
            new Cliente("prueba", "prueba")
        };
        Administrador administrador = new Administrador("admin", "123");



        public MainWindow()
        {
            InitializeComponent();
            ActualizarSaldo();
        }

        private void ActualizarSaldo()
        {
            txtSaldoGlobal.Text = saldo.ToString();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsuario.Text)
                || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtMensajeLogin.Text = "Debe completar ambos campos";
            }

            bool credencial = usuarios
                .Any(u => u.Nombre.Equals(txtUsuario.Text, StringComparison.Ordinal)
                        && u.Contrasena.Equals(txtPass.Text, StringComparison.Ordinal));

            if (credencial)
            {
                PantallaLogin.IsVisible = false;
                PantallaJuegos.IsVisible = true;
                invitado = false;
            }
            else
            {
                txtMensajeLogin.Text = "Error de usuario o contraseña";
            }
        }
        private void ModoInvitado(object? sender, RoutedEventArgs e)
        {
            PantallaLogin.IsVisible = false;
            PantallaJuegos.IsVisible = true;
            invitado = true;

        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtRegUser.Text))
            {
                Cliente cliente = new Cliente(txtRegUser.Text, txtRegPass.Text);
                txtMensajeLogin.Text = "Registrado. Inicia sesión.";
                txtMensajeLogin.Foreground = Brushes.LightGreen;
            }
            else
            {
                txtMensajeLogin.Text = "Usuario inválido o ya existe";
            }
        }


        private void btregistrovip(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRegUser.Text)
                && !usuarios.Exists(c => c.Nombre.Equals(txtRegUser.Text, StringComparison.Ordinal)))
            {

                txtMensajeLogin.Text = "Registrado. Inicia sesión.";
                txtMensajeLogin.Foreground = Brushes.LightGreen;
            }
            else
            {
                txtMensajeLogin.Text = "Usuario inválido o ya existe";
            }
        }
        private void BtnRuleta_Click(object sender, RoutedEventArgs e)
        {
            int apuesta = 0;
            if (invitado)
            {
                txtResultadoRuleta.Text = "Tienes que registrarte para jugar.";

            }
            else
            {
                if (!int.TryParse(txtApuestaRuleta.Text, out apuesta) || apuesta > saldo) return;

                saldo -= apuesta;


                int ganador = random.Next(0, 6);
                string colorG = "Negro";
                if (ganador > 0)
                {
                    colorG = "Verde";
                }
                else if (ganador % 2 == 0)
                {
                    colorG = "Rojo";
                }

                int ganancia = 0;

                if (rbNumero.IsChecked.HasValue && rbNumero.IsChecked.Value)
                {
                    if (txtNumRuleta.Text == ganador.ToString()) ganancia = apuesta * 5;
                }
                else if (rbColor.IsChecked.HasValue && rbColor.IsChecked.Value)
                {
                    ComboBoxItem item = (ComboBoxItem)cmbColor.SelectedItem;
                    if (item.Content.ToString().Equals(colorG, StringComparison.Ordinal)) ganancia = apuesta * 2;
                }

                if (ganancia > 0)
                {
                    saldo += ganancia;
                    txtResultadoRuleta.Text = $"¡GANASTE {ganancia}! Salió: {ganador} ({colorG})";
                    txtResultadoRuleta.Foreground = Brushes.Gold;
                }
                else
                {
                    txtResultadoRuleta.Text = $"Perdiste. Salió: {ganador} ({colorG})";
                    txtResultadoRuleta.Foreground = Brushes.White;
                }
                ActualizarSaldo();

            }
        }

        private void BtnDado_Click(object sender, RoutedEventArgs e)
        {
            int apuesta = 0;
            if (invitado == true)
            {
                txtResultadoDados.Text = "Tienes que registrarte para jugar.";

            }
            else
            {
                if (!int.TryParse(txtApuestaDado.Text, out apuesta) || apuesta > saldo) return;
                if (string.IsNullOrWhiteSpace(valordados.Text)) return;

                saldo -= apuesta;

                int d1 = random.Next(1, 7);
                int d2 = random.Next(1, 7);
                int total = d1 + d2;

                valorrealdado.Text = total.ToString();

                if (valordados.Text == total.ToString())
                {
                    int premio = apuesta * 5;
                    saldo += premio;
                    txtResultadoDados.Text = $"¡ACERTASTE! Ganas {premio}";
                    txtResultadoDados.Foreground = Brushes.Gold;
                }
                else
                {
                    txtResultadoDados.Text = "Intenta de nuevo";
                    txtResultadoDados.Foreground = Brushes.White;
                }
                ActualizarSaldo();
            }
        }

        private void BtnTraga_Click(object sender, RoutedEventArgs e)
        {
            int apuesta = 0;

            if (invitado == true)
            {
                txtResultadoSlot.Text = "Tienes que registrarte para jugar";
            }
            else
            {
                if (!int.TryParse(txtApuestaTraga.Text, out apuesta) || apuesta > saldo) return;

                saldo -= apuesta;

                string[] simbolos = { "1", "2", "3", "4", "5", "6", "7" };

                string s1 = simbolos[random.Next(0, 7)];
                string s2 = simbolos[random.Next(0, 7)];
                string s3 = simbolos[random.Next(0, 7)];

                slot1.Text = s1;
                slot2.Text = s2;
                slot3.Text = s3;

                if (s1 == s2 && s2 == s3)
                {
                    int premio = apuesta * 10;
                    saldo += premio;
                    txtResultadoSlot.Text = $"¡JACKPOT! Ganas {premio}";
                    txtResultadoSlot.Foreground = Brushes.Gold;
                }
                else if (s1 == s2 || s2 == s3 || s1 == s3)
                {
                    int premio = apuesta * 2;
                    saldo += premio;
                    txtResultadoSlot.Text = $"¡PAR! Ganas {premio}";
                    txtResultadoSlot.Foreground = Brushes.LightGreen;
                }
                else
                {
                    txtResultadoSlot.Text = "";
                }
                ActualizarSaldo();
            }
        }

        private void BtnIniciarBJ_Click(object sender, RoutedEventArgs e)
        {
            int apuesta = 0;
            if (invitado == true)
            {
                txtResultadoBlackjack.Text = "tienes que registrarte para jugar";

            }
            else
            {
                if (!int.TryParse(txtApuestaBJ.Text, out apuesta) || apuesta > saldo) return;

                saldo -= apuesta;
                apuestaActualBJ = apuesta;
                ActualizarSaldo();

                juegoActivoBJ = true;
                cuentaJugador = random.Next(1, 12) + random.Next(1, 12);
                cuentaCrupier = 0;
                txtCartasJugador.Text = "Tus cartas: " + cuentaJugador;
                txtCartasCrupier.Text = "Crupier: ?";
                txtResultadoBlackjack.Text = "JUEGO EN CURSO";
                txtResultadoBlackjack.Foreground = Brushes.White;
            }
        }
        private void BtnPedir_Click(object sender, RoutedEventArgs e)
        {
            if (!juegoActivoBJ) return;

            cuentaJugador += random.Next(1, 12);
            txtCartasJugador.Text = "Tus cartas: " + cuentaJugador;

            if (cuentaJugador > 21)
            {
                txtResultadoBlackjack.Text = "PERDISTE";
                txtResultadoBlackjack.Foreground = Brushes.Red;
                juegoActivoBJ = false;
            }
        }

        private void BtnPlantarse_Click(object sender, RoutedEventArgs e)
        {
            if (!juegoActivoBJ) return;

            cuentaCrupier = random.Next(1, 12) + random.Next(1, 12);
            while (cuentaCrupier < 17)
            {
                cuentaCrupier += random.Next(1, 12);
            }

            txtCartasCrupier.Text = "Crupier: " + cuentaCrupier;

            if (cuentaCrupier > 21 || cuentaJugador > cuentaCrupier)
            {
                int premio = apuestaActualBJ * 2;
                saldo += premio;
                txtResultadoBlackjack.Text = $"¡GANASTE {premio}!";
                txtResultadoBlackjack.Foreground = Brushes.Gold;
            }
            else if (cuentaJugador == cuentaCrupier)
            {
                saldo += apuestaActualBJ;
                txtResultadoBlackjack.Text = "EMPATE";
                txtResultadoBlackjack.Foreground = Brushes.Cyan;
            }
            else
            {
                txtResultadoBlackjack.Text = "LA CASA GANA";
                txtResultadoBlackjack.Foreground = Brushes.White;
            }

            juegoActivoBJ = false;
            ActualizarSaldo();
        }


    }
}