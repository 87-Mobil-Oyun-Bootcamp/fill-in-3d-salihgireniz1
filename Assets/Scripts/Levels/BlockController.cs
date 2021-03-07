﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockState
{
    Default = 0,
    Collected
}

public class BlockController : MonoBehaviour
{
    public BlockState BlockState
    {
        get
        {
            return blockState;
        }

        set
        {
            blockState = value;

            switch (blockState)
            {
                case BlockState.Default:

                    OnCreated?.Invoke(this);

                    break;
                case BlockState.Collected:

                    OnCollected?.Invoke(this);

                    OnCreated -= LevelManager.Instance.OnBlockCreated;
                    OnCollected -= LevelManager.Instance.OnBlockCollected;

                    break;
                default:
                    break;
            }
        }
    }

    public System.Action<BlockController> OnCreated { get; set; }
    public System.Action<BlockController> OnCollected { get; set; }

    BlockState blockState = BlockState.Default;

    private void Start()
    {
        BlockState = BlockState.Default;
    }

    private void OnEnable()
    {
        OnCreated += LevelManager.Instance.OnBlockCreated;
        OnCollected += LevelManager.Instance.OnBlockCollected;
    }
}
