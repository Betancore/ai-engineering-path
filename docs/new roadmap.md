# Roadmap: AI Engineer for .NET & QA Expert (10+ Years Experience)

## Концепция обучения
Иерархический переход от фундаментальной математики к прикладному использованию AI в экосистеме .NET. План ориентирован на опытного инженера, где глубина понимания "под капотом" сочетается с практической реализацией систем.

---

## Этап 1: Математический фундамент и подготовка (Data Science)
*Цель: Освоение математического аппарата и инструментария для работы с данными.*

### Темы для изучения:
*   **Линейная алгебра:** Матрицы, векторы, тензоры, операции над ними.
*   **Математический анализ:** Производные, функции потерь и алгоритм градиентного спуска.
*   **Теория вероятностей и статистика:** Распределения, статистические гипотезы, корреляция, Байесовская вероятность.
*   **Python для инженера:** Основы синтаксиса, работа в Jupyter Notebooks, библиотеки NumPy и Pandas.

### Ресурсы:
1.  **Книга:** *«Practical Statistics for Data Scientists»* (Peter Bruce).
2.  **Курс:** [Mathematics for Machine Learning Specialization](https://www.coursera.org/specializations/mathematics-machine-learning) (Imperial College London).
3.  **Инструментарий:** Jupyter Notebook (или Polyglot Notebooks в VS Code).

---

## Этап 2: Классическое машинное обучение (Classical ML)
*Цель: Изучение алгоритмов обучения без нейросетей и метрик качества.*

### Темы для изучения:
*   **Supervised Learning:** Линейная и логистическая регрессия, деревья решений (Decision Trees), Random Forest, Gradient Boosting (XGBoost/LightGBM).
*   **Unsupervised Learning:** Кластеризация (K-means), понижение размерности (PCA).
*   **Метрики и валидация:** Precision, Recall, F1-score, ROC-AUC, MSE/MAE. Кросс-валидация.

### Ресурсы:
1.  **Курс:** [Machine Learning Specialization](https://www.coursera.org/specializations/machine-learning-introduction) (Andrew Ng).
2.  **Книга:** *«Hands-On Machine Learning with Scikit-Learn, Keras, and TensorFlow»* (Aurélien Géron) — Часть 1.
3.  **Практика на .NET:** Использование библиотеки **ML.NET** для реализации аналогичных алгоритмов на C#.

---

## Этап 3: Deep Learning и Архитектура Transformer
*Цель: Понимание внутреннего устройства нейросетей и современных LLM.*

### Темы для изучения:
*   **Нейронные сети:** Полносвязные слои, функции активации (ReLU, Softmax), Backpropagation.
*   **NLP (Natural Language Processing):** Токенизация, Эмбеддинги (Word2Vec), Архитектура Encoder-Decoder.
*   **Attention Mechanism:** Глубокий разбор статьи *"Attention Is All You Need"*.
*   **Архитектура Transformer:** GPT, BERT, T5.

### Ресурсы:
1.  **YouTube/Курс:** [Andrej Karpathy "Zero to Hero"](https://karpathy.ai/zero-to-hero.html) (Создание GPT с нуля).
2.  **Курс:** [Fast.ai - Practical Deep Learning for Coders](https://course.fast.ai/).
3.  **Статья:** [Attention Is All You Need (Original Paper)](https://arxiv.org/abs/1706.03762).

---

## Этап 4: Инженерия AI в экосистеме .NET
*Цель: Профессиональная разработка AI-решений на стеке Microsoft.*

### Темы для изучения:
*   **Semantic Kernel (SDK):** Плагины, функции (Native & Semantic), цепочки вызовов.
*   **RAG (Retrieval-Augmented Generation):** Интеграция LLM с внешними данными.
*   **Векторные БД:** Работа с Qdrant, Milvus или Azure AI Search через C# SDK.
*   **Prompt Engineering:** Few-shot prompting, Chain-of-Thought, системные инструкции.

### Ресурсы:
1.  **Документация:** [Microsoft Semantic Kernel Documentation](https://learn.microsoft.com/en-us/semantic-kernel/).
2.  **Microsoft Learn:** Путь [Create AI solutions with Azure OpenAI Service](https://learn.microsoft.com/en-us/training/paths/develop-ai-solutions-azure-openai/).
3.  **GitHub:** [Semantic Kernel Samples](https://github.com/microsoft/semantic-kernel).

---

## Этап 5: AI в Testing & DevOps (QA Expert Level)
*Цель: Применение AI для обеспечения качества и автоматизации процессов.*

### Темы для изучения:
*   **Тестирование AI-систем:** Оценка галлюцинаций, стабильности и безопасности (Prompt Injection).
*   **LLM Evaluation:** Использование фреймворков Promptfoo, DeepEval или G-Eval.
*   **AI-Assisted Testing:** Агенты для генерации тестов на C# (xUnit/NUnit) и анализа результатов прогонов.

---

## Трекинг прогресса и практика

### Система контроля (Review)
1.  **Repository-Based Learning:** Каждый изученный модуль сопровождается коммитом кода (Python/C#) в папку `exercises/`.
2.  **AI-Mentor Check:** Использование Claude/GPT-4 для код-ревью и проведения "экзаменационных" вопросов по каждой теме.

### Контрольные проекты
*   **Проект 1 (ML):** Предсказание регрессионной модели на базе открытых данных (ML.NET).
*   **Проект 2 (Deep Learning):** Собственная реализация простого GPT-like классификатора текстов.
*   **Проект 3 (Full Stack AI):** RAG-агент на .NET/Semantic Kernel, работающий с локальной базой знаний (Markdown/PDF).

---
*Дата начала: [Вставь дату]*
*План составлен для: Senior QA Automation / .NET Engineer*