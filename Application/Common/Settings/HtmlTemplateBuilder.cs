using OfferMakerForCggCQRS.Application.Offers.Commands.ConvertOfferToPdf;
using System.Text;


namespace OfferMakerForCggCQRS.Application.Common.Settings
{
    public class HtmlTemplateBuilder
    {
        public static string HtmlStringBuilder(ConvertOfferToPdfCommand offer)
        {
            var stringBuilder = new StringBuilder();
            int countProducts = 0;
            // header
            stringBuilder.Append($"<html><head></head><body><div class='header'><h1 class='offerNumber'>Ofera numer: #{offer.Id}</h1><h3 class='offerDate'>Oferta z dnia: 2021-05-05</h3></div>");
            // contractors
            stringBuilder.Append($"<div class='contractors'><div class='offerFor'><h3>Oferta dla:</h3><p>{offer.Client.Name}<span>Nip: {offer.Client.Nip}</span><span>{offer.Client.PostalCode} {offer.Client.City}, {offer.Client.Street}</span></p></div>");
            stringBuilder.Append($"<div class='offerFrom'><h3>Ofertę składa:</h3><p>Test company<span>Nip: 444 - 4444 </span><span>06-400 Ciechanów, ul.Ulica 1/6</span></p></div></div>");

            // table

            //thead
            stringBuilder.Append($"<div class='items'><table><thead><tr><th>#</th><th>Nazwa</th><th>Ilosc</th><th>cena</th><th>cena laczna</th></tr></thead>");
            //tbody
            stringBuilder.Append($"<tbody>");
            foreach(var p in offer.Products)
            {
                countProducts = countProducts++;
                stringBuilder.Append($"<tr><td>{countProducts}</td><td>{p.Name}</td><td>{p.Quantity}</td><td>{p.PriceEach}</td><td>{p.PriceTotal}</td></tr>");
            }

            stringBuilder.Append($"<tr><td class='td1' colspan='4' style='text-align:center'>Razem:</td><td class='td2'>total</td></tr></tbody></table></div>");

            //end
            stringBuilder.Append($"</body></html>");

            return stringBuilder.ToString();
        }
     

    }
}
