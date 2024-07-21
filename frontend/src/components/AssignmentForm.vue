<template>
  <form @submit.prevent="submit">
    <v-text-field
      v-model="name.value.value"
      :counter="25"
      :error-messages="name.errorMessage.value"
      label="Name"
    />
    <v-row class="d-flex flex-row gap-4 mb-3 ms-1" dense>
      <input
        type="text"
        onfocus="(this.type='date')"
        onblur="(this.type='text')"
        placeholder="  Von"
        class="datepickers"
        v-model="startDate"
      />
      <input
        type="text"
        onfocus="(this.type='date')"
        onblur="(this.type='text')"
        placeholder="  Bis"
        class="datepickers"
        v-model="endDate"
      />
    </v-row>

    <v-btn theme="dark" class="me-4" type="submit"> submit </v-btn>

    <v-btn @click="reset"> clear </v-btn>
  </form>
</template>

<script setup lang="ts">
import { useField, useForm } from 'vee-validate'
import { ref } from 'vue'

const startDate = ref('')
const endDate = ref('')

const { handleSubmit, handleReset } = useForm({
  validationSchema: {
    name(value: string) {
      if (value?.length >= 2) return true

      return 'Name needs to be at least 2 characters.'
    },
    select(value: boolean) {
      if (value) return true

      return 'Select an item.'
    }
  }
})
const name = useField('name')

const submit = handleSubmit((values) => {
  alert(JSON.stringify(values, null, 2))
})

const reset = () => {
  handleReset()
  startDate.value = ''
  endDate.value = ''
}
</script>

<style scoped>
.datepickers {
  background-color: #e3e6e8;
  width: calc(50% - 0.9rem);
  min-height: 3.5rem;
  border-radius: 5px 5px 0 0;
  border-bottom: solid 1px #aaaeb0;
}
</style>
