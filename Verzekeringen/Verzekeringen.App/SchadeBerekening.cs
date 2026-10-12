
namespace Verzekeringen.App;

public class SchadeBerekening
{
    private const decimal MaximaalEigenRisico = 500m;
    
    public static (decimal uitkering, decimal toegepastEigenRisico) BerekenUitkering(decimal schadeBedrag, decimal eigenRisico)
    {
        // toegepast eigen risico is maximaal 500;

        decimal toegepastEigenRisico = Math.Min(eigenRisico, MaximaalEigenRisico);
        
        decimal uitkering = schadeBedrag - toegepastEigenRisico;

        if (uitkering < 0) {
            uitkering = 0;
        }

        return (uitkering, toegepastEigenRisico);
    }
}
