import '@/assets/main.css'
import { createApp } from 'vue'
import App from '@/App.vue'
import pinia from '@/domain/pinia'

const app = createApp(App)

app.use(pinia)

app.mount('#app')
