window.onload= mueveReloj

function mueveReloj() {

   reloj= new Date();

   hora=reloj.getHours();
   min= reloj.getMinutes();
   seg= reloj.getSeconds();

   str_segundo= new String(seg)
   if (str_segundo.length==1) {
    seg="0"+seg;
   }

   str_min= new String(min)
   if (str_min.length==1) {
    min="0"+min;
   }

   str_hora= new String(hora)
   if (str_hora.length==1) {
    hora="0"+hora;
   }

   horaImprimir=hora+":"+min+":"+seg;

   document.form_reloj.reloj.value=horaImprimir;

   setTimeout("mueveReloj()", 1000);

  
}