using System.Collections.Generic;

namespace CURS.Domain.Dtos
{
    public class ProgrammesListDto
    {
        public ProgrammesListDto()
        {
            PivotData = new LinkedList<List<object>>();
                               PivotData.AddLast(
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
                                   });
        }
        public int Error { get; set; }

        public LinkedList<List<object>> PivotData { get; set; }
    }
}