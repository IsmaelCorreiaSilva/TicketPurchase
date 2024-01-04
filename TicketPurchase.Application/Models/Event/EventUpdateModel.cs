﻿namespace TicketPurchase.Application.Models.Event
{
    /// <summary>
    /// Objeto usado para atualização de um Evento
    /// </summary>
    public class EventUpdateModel
    {
        /// <summary>
        /// Id do Evento
        /// </summary>
        /// <example>08dc0a0b-353c-456f-8372-03c7e6326add</example>
        public Guid Id { get; set; }
        /// <summary>
        /// Título do Evento
        /// </summary>
        /// <example>Rock in Rio 2024</example>
        public string Title { get; set; }
        /// <summary>
        /// Data que ocorrerá o evento
        /// </summary>
        /// <example>2024-10-05</example>
        public DateTime Date { get; set; }
        /// <summary>
        /// Descrição do Evento
        /// </summary>
        /// <example>Festival de Rock</example>
        public string Description { get; set; }
        /// <summary>
        /// Descrição da duração do Evento
        /// </summary>
        /// <example>3 dias</example>
        public string Duration { get; set; }
        /// <summary>
        /// Número máximo de pessoas que Evento comparta
        /// </summary>
        /// <example>20000</example>
        public int NumberVacancies { get; set; }
    }
}
