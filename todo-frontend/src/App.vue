<template>
  <div class="container">
    <div class="card">
      <h1>Task Manager 🚀</h1>
      <p class="subtitle">Full Stack: .NET 10 + Vue.js 3</p>
      
      <div class="divider"></div>

      <ul v-if="tarefas.length > 0">
        <li v-for="item in tarefas" :key="item.id" class="task-item">
          <span class="task-name">{{ item.name }}</span>
          <span :class="['status-badge', item.isComplete ? 'done' : 'pending']">
            {{ item.isComplete ? '✔ Concluído' : '⏳ Pendente' }}
          </span>
        </li>
      </ul>
      
      <div v-else class="loading">
        <p>Buscando tarefas no servidor...</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const tarefas = ref([])

onMounted(async () => {
  try {
    // A porta 5024 é a que o seu dotnet run está usando
    const response = await axios.get('http://localhost:5024/api/todo')
    tarefas.value = response.data
  } catch (error) {
    console.error("Erro ao conectar no backend:", error)
  }
})
</script>

<style scoped>
/* O CSS abaixo deixa o visual bonito e centralizado */
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f0f2f5;
  font-family: 'Segoe UI', system-ui, sans-serif;
}

.card {
  background: white;
  padding: 2rem;
  border-radius: 12px;
  box-shadow: 0 8px 24px rgba(0,0,0,0.1);
  width: 100%;
  max-width: 450px;
}

h1 {
  margin: 0;
  color: #1a1a1a;
  text-align: center;
}

.subtitle {
  text-align: center;
  color: #666;
  font-size: 0.9rem;
  margin-top: 5px;
}

.divider {
  height: 1px;
  background: #eee;
  margin: 20px 0;
}

ul {
  list-style: none;
  padding: 0;
}

.task-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 12px;
  border-bottom: 1px solid #f9f9f9;
}

.task-name {
  font-weight: 500;
  color: #333;
}

.status-badge {
  font-size: 0.75rem;
  padding: 4px 8px;
  border-radius: 20px;
  font-weight: bold;
}

.done {
  background: #e6fffa;
  color: #047857;
}

.pending {
  background: #fff5f5;
  color: #c53030;
}

.loading {
  text-align: center;
  color: #999;
  padding: 20px;
}
</style>