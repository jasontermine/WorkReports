import '@/assets/main.css'
import { createApp } from 'vue'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import App from '@/App.vue'
import pinia from '@/domain/pinia'
import router from "@/router/index";

const app = createApp(App)

const vuetify = createVuetify({
    components,
    directives,
    theme: {
      defaultTheme: 'dark',
    }
  })

app.use(pinia)
app.use(vuetify)
app.use(router);

app.mount('#app')
