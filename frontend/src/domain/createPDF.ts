import jsPDF from 'jspdf'
import autoTable, { type UserOptions } from 'jspdf-autotable'
import type { FilteredWorkHours } from '@/types/FilteredWorkHours'

/**
 * Downloads a PDF file containing a table with filtered work hours.
 * 
 * @param selectedAssignmentName - The name of the selected assignment.
 * @param filteredWorkHours - An array of filtered work hours.
 * @param totalHours - The total number of hours.
 */
export const onDownload = (selectedAssignmentName: string, filteredWorkHours: Array<FilteredWorkHours>, totalHours: number) => {
  const pdf = new jsPDF('l', 'pt', 'a4')
  const margin = 20
  
  const tableConfig: UserOptions = {
    useCss: true,
    headStyles: { fillColor: [192, 192, 192], lineColor: [0, 0, 0] },
    footStyles: { fillColor: [192, 192, 192] },
    tableLineColor: [0, 0, 0],
    theme: 'plain',
    head: [['Arbeiter', 'Datum', 'Stunden']],
    body: filteredWorkHours.map((entry: any) => [entry.employeeName, entry.date, entry.hours]),
    bodyStyles: { lineColor: [0, 0, 0] },
    foot: [['', 'Total', totalHours]],
    startY: 60,
    margin: { left: margin, right: margin },
    didDrawCell: (data: any) => {
      const doc = data.doc
      const cell = data.cell

      if (data.section === 'body') {
        const lineColor = [192, 192, 192]
        doc.setDrawColor(...lineColor)
        doc.setLineWidth(0.5)
        doc.line(cell.x, cell.y + cell.height, cell.x + cell.width, cell.y + cell.height)
      }
    }
  }

  const fromDate = filteredWorkHours.length > 0 ? filteredWorkHours[0].date : '';
  const toDate = filteredWorkHours.length > 0 ? filteredWorkHours[filteredWorkHours.length - 1].date : '';
  const assignmentNameText = `Regie Rapport für ${selectedAssignmentName}`;
  const periodText = `Periode: ${fromDate} bis ${toDate}`;
  const pdfName = `Regie_Rapport_${selectedAssignmentName.replace(" ", "-")}_${fromDate.replace(/-/g, '')}_bis_${toDate.replace(/-/g, '')}.pdf`;

  pdf.setFontSize(18);
  const assignmentNameY = margin + 10;
  pdf.text(assignmentNameText, margin, assignmentNameY);

  pdf.setFontSize(12);
  const periodY = margin + 30;
  pdf.text(periodText, margin, periodY);

  autoTable(pdf, tableConfig);

  pdf.save(pdfName);
}
