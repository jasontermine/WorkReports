import { ref } from "vue";

export const employees = ref([
    {
      id: 1,
      name: 'Test Testos',
      work_hours: [
        { assignment_id: 1, date: '2024-01-01', hours: 8 },
        { assignment_id: 1, date: '2024-01-02', hours: 7.5 },
        { assignment_id: 2, date: '2024-01-03', hours: 8 },
        { assignment_id: 1, date: '2024-01-04', hours: 6 },
        { assignment_id: 2, date: '2024-01-05', hours: 8 },
        { assignment_id: 1, date: '2024-01-06', hours: 7 }
      ]
    },
    {
      id: 2,
      name: 'El Jefe',
      work_hours: [
        { assignment_id: 2, date: '2024-01-01', hours: 6 },
        { assignment_id: 1, date: '2024-01-02', hours: 8 },
        { assignment_id: 2, date: '2024-01-03', hours: 7 },
        { assignment_id: 1, date: '2024-01-04', hours: 8 },
        { assignment_id: 2, date: '2024-01-05', hours: 7 },
        { assignment_id: 1, date: '2024-01-06', hours: 8 }
      ]
    }
  ])