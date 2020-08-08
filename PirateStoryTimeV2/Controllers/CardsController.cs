using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PirateStoryTimeV2.Models;
using PirateStoryTimeV2.Services;

namespace PirateStoryTimeV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardService _CardService;

        public CardsController(CardService CardService)
        {
            _CardService = CardService;
        }

        [HttpGet]
        public ActionResult<List<Card>> Get() =>
            _CardService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCard")]
        public ActionResult<Card> Get(string id)
        {
            var Card = _CardService.Get(id);

            if (Card == null)
            {
                return NotFound();
            }

            return Card;
        }

        [HttpPost]
        public ActionResult<Card> Create(Card Card)
        {
            _CardService.Create(Card);

            return CreatedAtRoute("GetCard", new { id = Card.Id.ToString() }, Card);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Card CardIn)
        {
            var Card = _CardService.Get(id);

            if (Card == null)
            {
                return NotFound();
            }

            _CardService.Update(id, CardIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Card = _CardService.Get(id);

            if (Card == null)
            {
                return NotFound();
            }

            _CardService.Remove(Card.Id);

            return NoContent();
        }
    }
}
