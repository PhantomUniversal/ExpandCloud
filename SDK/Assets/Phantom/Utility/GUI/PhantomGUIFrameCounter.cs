using UnityEngine;

namespace Phantom
{
    public class PhantomGUIFrameCounter
    {
        private int frameCount;
        private bool isNewFrame = true;
        private bool nextEventIsNew = true;

        /// <summary>Gets the frame count.</summary>
        public int FrameCount => this.frameCount;

        /// <summary>
        /// Gets a value indicating whether this instance is new frame.
        /// </summary>
        public bool IsNewFrame => this.isNewFrame;

        /// <summary>Updates the frame counter and returns itself.</summary>
        public PhantomGUIFrameCounter Update()
        {
            if (Event.current == null)
                return this;
            
            EventType type = Event.current.type;
            if (type == EventType.Repaint)
            {
                this.nextEventIsNew = true;
                this.isNewFrame = false;
                return this;
            }
            if (this.nextEventIsNew && type != EventType.Repaint)
            {
                ++this.frameCount;
                this.nextEventIsNew = false;
                this.isNewFrame = true;
                return this;
            }
            this.isNewFrame = false;
            return this;
        }
    }
}