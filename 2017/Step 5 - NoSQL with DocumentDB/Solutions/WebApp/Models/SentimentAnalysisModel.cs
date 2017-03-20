using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SentimentAnalysisModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public double Sentiment { get; set; }
    }
}
