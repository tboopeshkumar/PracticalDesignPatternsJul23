using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

public class Resume
{

    private string firstName, lastName, address, email, phone;
    private string[] education, skills, experience, interests;
    public Resume Build()
    {
        var pdf = new Document();
        PdfWriter.GetInstance(pdf, File.Create("resume.pdf"));
        pdf.Open();
        pdf.NewPage();
        var paraFont = new Font(Font.FontFamily.HELVETICA, 16f);
        var header = firstName + "  " + lastName + "      " + email + "/" + phone;
        var para = new Paragraph(header, paraFont);
        pdf.Add(para);
        pdf.Add(Chunk.NEWLINE);
        pdf.Add(new LineSeparator());
        pdf.Add(Chunk.NEWLINE);

        pdf.Add(new Paragraph("Address", paraFont));
        pdf.Add(new Phrase(address));
        pdf.Add(Chunk.NEWLINE);
        pdf.Add(Chunk.NEWLINE);

        pdf.Add(new Paragraph("Education", paraFont));
        foreach (var edu in education)
        {
            pdf.Add(new Phrase(edu));
        }
        pdf.Add(Chunk.NEWLINE);
        pdf.Add(Chunk.NEWLINE);

        pdf.Add(new Paragraph("Skills", paraFont));
        foreach (var skill in skills)
        {
            pdf.Add(new Phrase(skill));
            pdf.Add(Chunk.NEWLINE);
        }
        pdf.Add(Chunk.NEWLINE);

        pdf.Add(new Paragraph("Experience", paraFont));
        foreach (var exp in experience)
        {
            pdf.Add(new Phrase(exp));
            pdf.Add(Chunk.NEWLINE);
        }
        pdf.Add(Chunk.NEWLINE);

        pdf.Add(new Paragraph("Interests", paraFont));
        foreach (var interest in interests)
        {
            pdf.Add(new Phrase(interest));
            pdf.Add(Chunk.NEWLINE);
        }
        pdf.Add(Chunk.NEWLINE);

        pdf.Close();

        return this;
    }

    public Resume AddFirstName(string value) { firstName = value; return this; }
    public Resume AddLastName(string value) { lastName = value; return this; }
    public Resume AddAddress(string value) { address = value; return this; }
    public Resume AddEmail(string value) { email = value; return this; }
    public Resume AddPhone(string value) { phone = value; return this; }
    public Resume AddEducation(string[] value) { education = value; return this; }
    public Resume AddSkills(string[] value) { skills = value; return this; }
    public Resume AddExperience(string[] value){ experience = value; return this; }
    public Resume AddInterests(string[] value) { interests = value; return this; }

    public static void Main(String[] args)  {

        var resume = new Resume();
        resume
          .AddFirstName("Anders")
          .AddLastName("Hejslberg")
          .AddAddress("WA US")
          .AddAddress("anders@microsoft.com")
          .AddPhone("1-800-ANDERS")
          .AddEducation(new String[] { "BE" })
          .AddSkills(new String[] { "Turbo Pascal", "Delphi", "C#", "TypeScript" })
          .AddExperience(new String[] { "Borland", "Microsoft" })
          .AddInterests(new String[] { "Calligraphy" })
          .Build();

  }
}
