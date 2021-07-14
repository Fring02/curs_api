using System.Collections.Generic;

namespace CURS.Domain.Dtos
{
    public class ProgrammesListDto
    {
        public ProgrammesListDto(int programmesCount)
        {
            PivotData = new List<List<object>>(programmesCount + 1)
            {
                new List<object>
                {
                    "ID",
                    "Дисциплина",
                    "Наименование ОП",
                    "Курс",
                    "Языковое отделение",
                    "Количество кредитов",
                    "Количество студентов",
                    "Количество групп",
                    "Количество подгрупп",
                    "Всего",
                    "Тип занятия",
                    "План-факт",
                    "Значение",
                    "Код группы",
                    "Код связи"
                }
            };
        }

        public ProgrammesListDto()
        {
            
        }
        public int Error { get; set; }

        public List<List<object>> PivotData { get; set; }
    }
}