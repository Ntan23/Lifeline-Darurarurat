using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class Chat_DialogueLine : DialogueLine
    {
        private TMP_Text _nameTextContainer;
        private GameObject _nameContainer;
        private Image _spriteContainer;
        private GameObject _pressToContinueContainer;
        private bool _isWholeDialogueUseSprite;

        private INeedChatDialogue _getChatDialogueData;

        protected DialogueCharacter _currCharacter;
        public DialogueCharacter CurrCharacter { get { return _currCharacter; } set { _currCharacter = value; } }

        public void GetCharaContainer(TMP_Text nameTextContainer, Image spriteContainer, GameObject nameContainer, GameObject pressToCon, bool isWholeDialogueUseSprite)
        {
            _nameTextContainer = nameTextContainer;
            _spriteContainer = spriteContainer;
            _nameContainer = nameContainer;
            _pressToContinueContainer = pressToCon;
            _isWholeDialogueUseSprite = isWholeDialogueUseSprite;
        }
        public override void SetDialogue(Dialogue_Line dialogueInput)
        {
            _currdialogueInput = dialogueInput;
            _textContainer.text = "";
            
            _getChatDialogueData = dialogueInput as INeedChatDialogue;
            if(_getChatDialogueData.DialogueTypeNow == DialogueType.Character )
            {
                // _bgContainer.gameObject.SetActive(true);
                _nameTextContainer.text = CurrCharacter.name;
                if(_isWholeDialogueUseSprite)
                {
                    if(CurrCharacter.charaSprites.Length > 0 && _getChatDialogueData.SpriteNumber < CurrCharacter.charaSprites.Length && _getChatDialogueData.SpriteNumber >= 0)
                    {
                        _spriteContainer.sprite = CurrCharacter.charaSprites[_getChatDialogueData.SpriteNumber];
                        _spriteContainer.gameObject.SetActive(true);
                    }
                    else _spriteContainer.gameObject.SetActive(false);
                }
            }
            else if(_getChatDialogueData.DialogueTypeNow == DialogueType.Narration)
            {
                _nameTextContainer.text = "";

                if(_isWholeDialogueUseSprite)
                {
                    if(CurrCharacter.charaSprites.Length > 0 && _getChatDialogueData.SpriteNumber < CurrCharacter.charaSprites.Length && _getChatDialogueData.SpriteNumber >= 0)
                    {
                        _spriteContainer.sprite = CurrCharacter.charaSprites[_getChatDialogueData.SpriteNumber];
                        _spriteContainer.gameObject.SetActive(true);
                    }
                    else _spriteContainer.gameObject.SetActive(false);
                }
            }
            _nameContainer.SetActive(true);
            _nameTextContainer.gameObject.SetActive(true);
            

            
            _dialogue = typeText(dialogueInput.DialogueTextLocalized, _textContainer, dialogueInput.DelayTypeText, dialogueInput.DelayBetweenLines);

            // Debug.Log("???????");
            StartCoroutine(_dialogue);
        }

        public override void AfterDone_BeforeInput()
        {
            if(_pressToContinueContainer!= null)_pressToContinueContainer.SetActive(true);
        }
        public override void AfterDone_AfterInput()
        {
            if(_pressToContinueContainer!= null)_pressToContinueContainer.SetActive(false);
        }
    }

}
